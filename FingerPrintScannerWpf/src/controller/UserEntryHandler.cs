using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FingerPrintScanner.src.model;

namespace FingerPrintScanner.src.controller {

    public class UserEntryHandler {
        private int data_size;
        private UserEntryInfo uei;
        private UserBasicInfo ubi;
        public UserEntryHandler() {
            this.data_size = 0 ;
            this.uei = new UserEntryInfo() ;
            this.ubi = new UserBasicInfo() ;
        }

        public void loadLastTenEntryToDataGrid( DataGrid dgv_param) {
            string[] arr = new string[ 10 ] ;
            arr[ 0 ] = "User Full Name" ;
            arr[ 1 ] = "User Enroll ID" ;
            arr[ 2 ] = "User Entry Time" ;
            DataGridViewLoader.setData( dgv_param , arr , this.getLastTenEntry() , this.data_size , 1 ) ;
        }

        private string[ , ] getLastTenEntry() {
            int i ;
            this.uei.setLimit( 10 ) ;
            this.uei.setOrderByIndexIdDesc() ;
            this.uei.setRetrievalColumnUserId() ;
            this.uei.setRetrievalColumnUserEntryTime() ;
            string[ , ] arr = this.uei.getAllData() ;
            string[ , ] brr ;
            this.data_size = this.uei.getNumRows() ;
            for( i = 0 ; i < this.data_size ; i++ ) {
                UserBasicInfo ubi = new UserBasicInfo() ;
                ubi.setWhereClauseUserId( arr[ i , 0 ] ) ;
                ubi.setRetrievalColumnUserFirstName() ;
                ubi.setRetrievalColumnUserLastName() ;
                brr = ubi.getAllData() ;
                arr[ i , 2 ] = brr[ 0 , 0 ] + " " + brr[ 0 , 1 ] ;
            }
            return arr ;
        }

        public void insertEntryToTable( string enroll_id , string date_time_param ) {
            int a ;
            string[] arr ;
            arr = new string[ 100 ] ;
            a = 1 ;            
            try {
                string s;
                s = this.uei.getMaxId();                
                a = Int32.Parse( s ) ;
                a++ ;
            }
            catch( Exception ex ) {
                System.Windows.MessageBox.Show( "Error in parsing integer at UserEntryHandler controller!" ) ;
                return;
            }
            arr[ 0 ] = a.ToString() ;
            arr[ 1 ] = enroll_id ;
            arr[ 2 ] = date_time_param ;
            this.ubi.checkAndUpdateNewId( enroll_id ) ;
            this.uei.insert( arr ) ;
        }

        public string[ , ] getAllData() {
            int i , sz ;
            sz = this.uei.getNumRows() ;
            string[,] arr = this.uei.getAllData() ;
            for( i = 0 ; i < sz ; i++ ) {
                arr[ i , 0 ] = this.ubi.getASingleUserFullName( arr[ i , 0 ] ) ;
            }
            return arr ;
        }

        public int getDataSize() {
            return this.uei.getNumRows();
        }
    }
}
