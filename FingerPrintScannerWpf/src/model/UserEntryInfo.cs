using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Data ;
using System.Windows.Forms ;
using System.Threading.Tasks ;
using FingerPrintScanner.src.controller;

namespace FingerPrintScanner.src.model {
    public class UserEntryInfo : ModelDataController {
        public UserEntryInfo() {
            this.class_name = "user_entry_info" ;
            this.init() ;
        }

        public void setEntryDateTimeWhereClause( string value , bool is_greater_than_equal_sign ) {
            if( is_greater_than_equal_sign == true ) {
                this.setWhereClause( "entry_date_time" , value , 5 , true );
            }            
            else {
                this.setWhereClause( "entry_date_time" , value , 3 , true );
            }            
        }

        public string[ , ] getSearchQuery() {
            string[ , ] arr = this.getAllData();
            return arr;
        }

        public void setOrderByIndexIdDesc() {
            this.setOrderByDesc( "index_id" );
        }

        public void setRetrievalColumnUserId() {
            this.setResultantColumn( "user_id" );
        }
        public void setRetrievalColumnUserEntryTime() {
            this.setResultantColumn( "entry_date_time" );
        }

        public string getMaxId() {
            return this.getMaxIdGeneralized( "index_id" );
        }
    }
}
