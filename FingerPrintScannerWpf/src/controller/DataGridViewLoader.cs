using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Data ;
using System.IO ;
using System.Windows.Controls ;
using System.Threading.Tasks ;
using FingerPrintScanner.src.controller ;

namespace FingerPrintScanner.src.controller {    
    sealed public class DataGridViewLoader {
        
        private DataGridViewLoader() {
        }        
        
        public static void setData( DataGrid dgv , string[] column_names , string[ , ] data , int row_cn , int data_grid_bind_id ) {
            int i , j , a ;
            /*for( i = 0 ; i < col_cn ; i++ ) {
                DataGridTextColumn dgtcc = new DataGridTextColumn();
                a = 1;
                for( j = 0 ; j < dgv.Columns.Count ; j++ ) {
                    if( dgv.Columns[ j ].Header.ToString().CompareTo( column_names[ i ] ) == 0 ) {
                        a = 0 ;
                        break ;
                    }
                }
                dgtcc.Header = column_names[ i ];
                try {
                    if( a == 1 ) {
                        dgv.Columns.Add( dgtcc );
                    }                    
                }
                catch( Exception e ) {
                }
            }*/
            if( data_grid_bind_id == 1 ) {
                List<TypeOne> list_data = new List<TypeOne>();
                for( i = 0 ; i < row_cn ; i++ ) {
                    list_data.Add( new TypeOne() {
                        UserEnrollID = data[ i , 0 ] ,
                        UserEntryTime = data[ i , 1 ] ,
                        UserFullName = data[ i , 2 ] 
                    } ) ;
                    dgv.ItemsSource = list_data ;
                }
            }
            else if( data_grid_bind_id == 2 ) {
                List<TypeTwo> list_data = new List<TypeTwo>();
                for( i = 0 ; i < row_cn ; i++ ) {                    
                    list_data.Add( new TypeTwo() {
                        UserFullName = data[ i , 1 ] + " " + data[ i , 2 ] ,
                        UserJoinDate = data[ i , 8 ]                        
                    } ) ;
                    dgv.ItemsSource = list_data ;
                }
            }
            else if( data_grid_bind_id == 3 ) {
                List<TypeThree> list_data = new List<TypeThree>();
                for( i = 0 ; i < row_cn ; i++ ) {
                    list_data.Add( new TypeThree() {
                        UserFullName = data[ i , 0 ] ,
                        JobDesignation = data[ i , 1 ] ,
                        EntryTime = data[ i , 2 ]
                    } ) ;
                    dgv.ItemsSource = list_data ;
                }
            }
            else if( data_grid_bind_id == 4 ) {
                List<FourColumns> list_data = new List<FourColumns>() ;
                for( i = 0 ; i < row_cn ; i++ ) {
                    list_data.Add( new FourColumns() {
                        FirstColumn = data[ i , 0 ] ,
                        SecondColumn = data[ i , 1 ] ,
                        ThirdColumn = data[ i , 2 ] ,
                        FourthColumn = data[ i , 3 ]
                    } );
                    dgv.ItemsSource = list_data;
                }
            }
            else if( data_grid_bind_id == 5 ) {
                List<FiveColumns> list_data = new List<FiveColumns>();
                for( i = 0 ; i < row_cn ; i++ ) {
                    list_data.Add( new FiveColumns() {
                        FirstColumn = data[ i , 0 ] ,
                        SecondColumn = data[ i , 1 ] ,
                        ThirdColumn = data[ i , 2 ] ,
                        FourthColumn = data[ i , 3 ] ,
                        FifthColumn = data[ i , 4 ]
                    } );
                    dgv.ItemsSource = list_data;
                }
            }
            else if( data_grid_bind_id == 6 ) {
                List<SixColumns> list_data = new List<SixColumns>();
                for( i = 0 ; i < row_cn ; i++ ) {
                    list_data.Add( new SixColumns() {
                        FirstColumn = data[ i , 0 ] ,
                        SecondColumn = data[ i , 1 ] ,
                        ThirdColumn = data[ i , 2 ] ,
                        FourthColumn = data[ i , 3 ] ,
                        FifthColumn = data[ i , 4 ] ,
                        SixthColumn = data[ i , 5 ]
                    } );
                    dgv.ItemsSource = list_data;
                }
            }
            else if( data_grid_bind_id == 7 ) {
                List<SevenColumns> list_data = new List<SevenColumns>();
                for( i = 0 ; i < row_cn ; i++ ) {
                    list_data.Add( new SevenColumns() {
                        FirstColumn = data[ i , 0 ] ,
                        SecondColumn = data[ i , 1 ] ,
                        ThirdColumn = data[ i , 2 ] ,
                        FourthColumn = data[ i , 3 ] ,
                        FifthColumn = data[ i , 4 ] ,
                        SixthColumn = data[ i , 5 ] ,
                        SeventhColumn = data[ i , 6 ] 
                    } );
                    dgv.ItemsSource = list_data;                    
                }
            }
            else {
                throw new Exception( "No Handler Available for your request result set." );
            }
            dgv.Items.Refresh();            
        }        


        public class TypeOne {
            public string UserFullName {
                get ;
                set ;
            }
            public string UserEnrollID {
                get ;
                set ;
            }
            public string UserEntryTime {
                get ;
                set ;
            }
        }

        public class TypeTwo {
            public string UserFullName {
                get ;
                set ;
            }
            public string UserJoinDate {
                get ;
                set ;
            }            
        }

        public class TypeThree {
            public string UserFullName {
                get ;
                set ;
            }
            public string JobDesignation {
                get ;
                set ;
            }
            public string EntryTime {
                get ;
                set ;
            }
        }

        public class FourColumns {
            public string FirstColumn {
                get ;
                set ;
            }
            public string SecondColumn {
                get ;
                set ;
            }
            public string ThirdColumn {
                get ;
                set ;
            }
            public string FourthColumn {
                get ;
                set ;
            }
        }

        public class FiveColumns {
            public string FirstColumn {
                get ;
                set ;
            }
            public string SecondColumn {
                get ;
                set ;
            }
            public string ThirdColumn {
                get ;
                set ;
            }
            public string FourthColumn {
                get ;
                set ;
            }
            public string FifthColumn {
                get ;
                set ;
            }
        }

        public class SixColumns {
            public string FirstColumn {
                get ;
                set ;
            }
            public string SecondColumn {
                get ;
                set ;
            }
            public string ThirdColumn {
                get ;
                set ;
            }
            public string FourthColumn {
                get ;
                set ;
            }
            public string FifthColumn {
                get ;
                set ;
            }
            public string SixthColumn {
                get ;
                set ;
            }
        }

        public class SevenColumns {
            public string FirstColumn {
                get ;
                set ;
            }
            public string SecondColumn {
                get ;
                set ;
            }
            public string ThirdColumn {
                get ;
                set ;
            }
            public string FourthColumn {
                get ;
                set ;
            }
            public string FifthColumn {
                get ;
                set ;
            }
            public string SixthColumn {
                get ;
                set ;
            }
            public string SeventhColumn {
                get ;
                set ;
            }
        }
    }
}

