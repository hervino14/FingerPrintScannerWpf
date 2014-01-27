using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FingerPrintScanner.src.model ;

namespace FingerPrintScanner.src.controller {
    public class UserLogHandler {
        private UserEntryInfo uei;
        private UserBasicInfo ubi ;
        public UserLogHandler() {
            this.uei = new UserEntryInfo() ;
            this.ubi = new UserBasicInfo() ;
        }

        public void getAndSetQueryResult( DataGrid dgrid , string start_time , string end_time ) {
            int i , j , l1 ;
            this.uei.setEntryDateTimeWhereClause( start_time , true ) ;
            this.uei.setEntryDateTimeWhereClause( end_time , false );
            string[,] arr = this.uei.getSearchQuery();
            string[ , ] crr = new string[ EnvironmentVariableHandler.getArrayLimit() , EnvironmentVariableHandler.getArrayLimit() ];
            string[] brr = new string[ EnvironmentVariableHandler.getArrayLimit() ] ;
            brr[ 0 ] = "User Full Name" ;
            brr[ 1 ] = "Entry Time" ;
            l1 = this.uei.getNumRows();
            for( i = 0 ; i < l1 ; i++ ) {
                crr[ i , 0 ] = this.ubi.getASingleUserFullName( arr[ i , 1 ] );
                crr[ i , 1 ] = arr[ i , 2 ] ;                
            }
            DataGridViewLoader.setData( dgrid , brr , crr , l1 , 2 );
        }
    }
}

