using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Data ;
using System.Threading.Tasks ;
using FingerPrintScanner.src.controller ;

namespace FingerPrintScanner.src.model {
    public class UserBasicInfo : ModelDataController {        
        public UserBasicInfo() {
            this.class_name = "user_basic_info" ;
            this.init() ;
        }

        public string getASingleUserFullName( string user_id ) {
            this.setWhereClause( "user_id" , "1" , 6 , false ) ;
            string[ , ] arr = this.getAllData() ;
            return arr[ 0 , 1 ] + " " + arr[ 0 , 2 ] ;
        }

        public void setWhereClauseUserId( string user_id_param ) {
            this.setWhereClause( "user_id" , user_id_param , 6 , false ) ;
        }

        public void setWhereClauseUserFirstNameIsNull( string user_first_name_param ) {
            this.setWhereClause( "user_first_name" , user_first_name_param , 8 , false );
        }
        public void setWhereClauseUserLastNameIsNull( string user_last_name_param ) {
            this.setWhereClause( "user_last_name" , user_last_name_param , 8 , false );
        }

        public void setRetrievalColumnUserFirstName() {
            this.setResultantColumn( "user_first_name" );
        }

        public void setRetrievalColumnUserLastName() {
            this.setResultantColumn( "user_last_name" );
        }

        public void setRetrievalColumnUserId() {
            this.setResultantColumn( "user_id" );
        }

        public void checkAndUpdateNewId( string new_id ) {
            this.setWhereClauseUserId( new_id ) ;
            string[ , ] arr = this.getAllData() ;
            if( this.num_of_rows == 0 ) {
                string[] brr = new string[ 20 ] ;
                int i ;
                for( i = 0 ; i < 20 ; i++ ) {
                    brr[ i ] = "null" ;
                }
                brr[ 0 ] = new_id ;
                this.insert( brr ) ;
            }
        }

        public void updateUserInfo( string[] brr ) {
            this.setWhereClause( "user_id" , brr[ 0 ] , 6 , false ) ;
            this.setUpdateSetClause( "user_first_name" , brr[ 1 ] , true ) ;
            this.setUpdateSetClause( "user_last_name" , brr[ 2 ] , true ) ;
            this.setUpdateSetClause( "phone_number" , brr[ 3 ] , false ) ;
            this.setUpdateSetClause( "date_of_birth" , brr[ 4 ] , true ) ;
            this.setUpdateSetClause( "email_address" , brr[ 5 ] , true ) ;
            this.setUpdateSetClause( "current_address" , brr[ 6 ] , true ) ;
            this.setUpdateSetClause( "job_designation" , brr[ 7 ] , true ) ;
            this.setUpdateSetClause( "join_date" , brr[ 8 ] , true );
            this.update() ;
        }
    }
}
