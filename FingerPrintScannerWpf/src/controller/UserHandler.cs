using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.Windows.Controls ;
using FingerPrintScanner.src.model ;

namespace FingerPrintScanner.src.controller {
    public class UserHandler {
        private UserBasicInfo ubi ;
        private UserAdminInfo uai ;
        private string[,] user_id_list ;

        public UserHandler() {
            this.ubi = new UserBasicInfo() ;
            this.uai = new UserAdminInfo() ;
        }

        public int checkAdmin( string user_name , string password ) {
            int a , b , i , j ;
            int res ;
            string[,] arr = this.uai.getAllData() ;
            res = 4 ;
            a = this.uai.getNumRows() ;
            b = this.uai.getNumCols() ;
            if( user_name.CompareTo( "" ) == 0 ) {
                return res = 2 ;
            }
            if( password.CompareTo( "" ) == 0 ) {
                return res = 3 ;
            }
            for( i = 0 ; i < a ; i++ ) {
                if( arr[ i , 0 ] != null && arr[ i , 1 ] != null && arr[ i , 0 ].CompareTo( user_name ) == 0 && arr[ i , 1 ].CompareTo( Encryption.calculateMD5Hash( password ) ) == 0 ) {
                    res = 1 ;
                    break ;
                }                
            }            
            return res ;
        }

        public System.Windows.Forms.DataGridView getAllAdminUsers( System.Windows.Forms.DataGridView dgv ) {
            int i , j ;
            string[ , ] arr ;
            string[] brr ;
            brr = this.uai.getAllColumns() ;
            arr = this.uai.getAllData() ;            
            //dgv = DataGridViewLoader.setData( dgv , brr , arr , this.uai.getNumRows() , this.uai.getColumnSize() ) ;            
            return dgv;
        }

        public void getUserList() {
            int a , b , i , j ;
            string s ;
            string[ , ] arr = this.ubi.getAllData() ;
            a = this.ubi.getNumRows() ;
            b = this.ubi.getNumCols() ;
            s = "" ;
            for( i = 0 ; i < a ; i++ ) {
                for( j = 0 ; j < b ; j++ ) {
                    s += "," + arr[ i , j ] ;
                }
                s += "\n" ;
            }
            System.Windows.Forms.MessageBox.Show( s ) ;
        }

        public System.Windows.Forms.AutoCompleteStringCollection getUserFullNames( string name_param ) {
            int i , a , b ;
            System.Windows.Forms.AutoCompleteStringCollection asc;
            asc = new System.Windows.Forms.AutoCompleteStringCollection();
            this.ubi.setWhereClause( "user_first_name" , name_param , 6 , true ) ;
            this.ubi.setResultantColumn( "user_first_name" ) ;
            string[ , ] arr = this.ubi.getAllData() ;
            a = this.ubi.getNumRows() ;
            b = this.ubi.getNumCols() ;
            for( i = 0 ; i < a ; i++ ) {
                asc.Add( arr[ i , 0 ] ) ;
            }            
            return asc ;
        }

        public void insertNewAdmin( string user_name , string password , string full_name ) {
            string[] arr ;
            arr = new string[ EnvironmentVariableHandler.getArrayLimit() ] ;
            arr[ 0 ] = user_name ; 
            arr[ 1 ] = Encryption.calculateMD5Hash( password ) ; 
            arr[ 2 ] = full_name ; 
            this.uai.insert( arr ) ;
        }

        public string[ , ] getAllEmptyFullNameUsers() {
            this.ubi.setWhereClauseUserFirstNameIsNull( "NULL" ) ;
            this.ubi.setWhereClauseUserLastNameIsNull( "NULL" ) ;
            this.ubi.setRetrievalColumnUserId() ;
            return this.ubi.getAllData() ;
        }

        public int getDataSize() {
            return this.ubi.getNumRows();
        }

        public void insertNewUser( string[] brr ) {
            this.ubi.insert( brr ) ;
        }

        public void updateUser( string[] brr ) {
            this.ubi.updateUserInfo( brr ) ;
        }

        public string[ , ] getAllUserInfo() {
            return this.ubi.getAllData() ;
        }

        public void loadUserListToDataGrid( System.Windows.Controls.DataGrid dgv_param ) {
            string[] arr = new string[ 10 ] ;
            arr[ 0 ] = "User Full Name" ;
            arr[ 1 ] = "User Join Date" ;
            this.user_id_list = this.getAllUserInfo() ;
            DataGridViewLoader.setData( dgv_param , arr , this.user_id_list , this.ubi.getNumRows() , 2 ) ;
        }

        public string[,] getAllUserIdList() {
            return this.user_id_list ;
        }
    }
}

