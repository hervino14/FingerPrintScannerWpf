using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.Data ;
using System.Data.Common ;
using System.Windows.Forms ;
using System.Data.SqlClient ;


namespace FingerPrintScanner.src.controller {
    public class DbConnection {        
        private SqlConnection con_var ;
        private string error_msg ;
        public DbConnection() {
            this.con_var = null ;
            this.error_msg = "" ;
        }        

        private void init() {
            //this.con_var = new SqlConnection( "user id=sa;password=aMAss9bd;server=localhost\\SQLEXPRESS;database=employeeManagement;connection timeout=30;" );
            this.con_var = new SqlConnection( "Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\Development\\C#\\FingerPrintScannerWpf\\FingerPrintScannerWpf\\employeeManagement.mdf;Integrated Security=True;" ) ;            
        }

        private void openConnection() {
            try {
                if (this.con_var == null) {
                    this.init() ;
                }
                if( this.con_var.State != System.Data.ConnectionState.Open ) {
                    this.con_var.Open() ;                    
                }
            }
            catch( Exception e ) {
                this.error_msg += e.ToString() + "\n" ;                
            }                   
        }

        private void closeConnection() {
            try {
                if( this.con_var != null && this.con_var.State == System.Data.ConnectionState.Open ) {
                    this.con_var.Close() ;
                }
                this.con_var = null ;
            }
            catch( Exception e ) {
                this.error_msg += e.ToString() + "\n" ;
            }            
        }
        
        public DataSet getDataSet( string sql ) {
            this.openConnection() ;
            DataSet ds = new DataSet() ;
            try {
                SqlCommand cmd = new SqlCommand( sql , this.con_var ) ;
                SqlDataAdapter adp = new SqlDataAdapter( cmd ) ;                
                adp.Fill( ds ) ;                
            }
            catch( Exception e ) {
                this.error_msg += e.ToString() + "\n" ;
            }
            this.closeConnection() ;
            return ds;
        }

        public string getErrorMessage() {
            return this.error_msg ;
        }

        public int execute( string sql ) {
            int a ;
            a = -1;
            this.openConnection() ;
            SqlCommand cmd ;
            cmd = null ;
            try {
                cmd = new SqlCommand( sql , this.con_var ) ;
                a = cmd.ExecuteNonQuery();
            }
            catch( Exception e ) {                
                this.error_msg += e.ToString() + "\n" ;                
            }                  
            this.closeConnection() ;
            return a ;
        }

        public DataTable getDataTable( string sql ) {            
            DataSet ds = this.getDataSet( sql ) ;            
            if( ds.Tables.Count > 0 ) {
                return ds.Tables[ 0 ] ;
            }
            return null ;
        }
    }
}
