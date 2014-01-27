using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Data ;
using System.Windows.Controls ;
using System.Threading.Tasks ;
using FingerPrintScanner.src.controller;

namespace FingerPrintScanner.src.model {
    public class ModelDataController {
        protected string class_name , limit_clause , order_by_clause ;
        protected int array_size , where_clause_counter , num_of_rows , num_of_cols , column_size , resultant_columns_counter , set_clause_counter ;
        protected bool where_clause_exists , set_clause_exists ;
        protected string[] where_clause_key , where_clause_value , column_names , column_types , resultant_columns , set_clause_key , set_clause_value ;
        protected int[] where_clause_type_flag ;
        protected bool[] where_clause_with_or_without_qoutation_flag , set_clause_with_or_without_qoutation_flag ;
        protected string[,] data ;
        private DbConnection dc ;

        public ModelDataController() {            
        }

        protected void init() {
            this.dc = SingletonDbConnection.getInstance() ;
            this.array_size = EnvironmentVariableHandler.getArrayLimit() ;
            this.limit_clause = "";
            this.order_by_clause = "";
            this.where_clause_exists = false ;
            this.set_clause_exists = false ;
            this.where_clause_counter = 0 ;
            this.resultant_columns_counter = 0 ;
            this.set_clause_counter = 0;
            this.column_size = 0 ;
            this.where_clause_key = new string[ this.array_size ] ;
            Array.Clear( this.where_clause_key , 0 , this.where_clause_key.Length ) ;
            this.where_clause_value = new string[ this.array_size ] ;
            Array.Clear( this.where_clause_value , 0 , this.where_clause_value.Length ) ;
            this.where_clause_type_flag = new int[ this.array_size ];
            Array.Clear( this.where_clause_type_flag , 0 , this.where_clause_type_flag.Length );
            this.where_clause_with_or_without_qoutation_flag = new bool[ this.array_size ];
            Array.Clear( this.where_clause_with_or_without_qoutation_flag , 0 , this.where_clause_with_or_without_qoutation_flag.Length );
            this.set_clause_key = new string[ this.array_size ];
            Array.Clear( this.set_clause_key , 0 , this.set_clause_key.Length );
            this.set_clause_value = new string[ this.array_size ];
            Array.Clear( this.set_clause_value , 0 , this.set_clause_value.Length );
            this.set_clause_with_or_without_qoutation_flag = new bool[ this.array_size ];
            Array.Clear( this.set_clause_with_or_without_qoutation_flag , 0 , this.set_clause_with_or_without_qoutation_flag.Length );
            this.column_names = new string[ this.array_size ] ;            
            this.column_types = new string[ this.array_size ] ;
            this.resultant_columns = new string[ this.array_size ] ;
            this.data = new string[ this.array_size , this.array_size ] ;
            this.getTableDetails();
        }

        private string[,] getDataTable( string sql ) {            
            int sz1 , sz2 , i , j ;
            DataTable dt = this.dc.getDataTable( sql ) ;
            string[ , ] arr = new string[ this.array_size , this.array_size ] ;
            sz1 = dt.Rows.Count ;
            sz2 = 0 ;
            this.num_of_cols = 0 ;
            this.num_of_rows = 0 ;            
            for( i = 0 ; i < sz1 ; i++ ) {
                sz2 = dt.Rows[ i ].ItemArray.Length ;                
                for( j = 0 ; j < sz2 ; j++ ) {                    
                    arr[ i , j ] = dt.Rows[ i ].ItemArray[ j ].ToString() ;                    
                }                
            }            
            this.num_of_rows = sz1 ;
            this.num_of_cols = sz2 ;
            return arr ;
        }

        protected string getMaxIdGeneralized( string column_name_param ) {
            string[ , ] arr = this.getDataTable( "select max( " + column_name_param + " ) from " + this.class_name + " ; " ) ;
            if (arr[0, 0] == null || arr[0, 0] == "NULL" || arr[0, 0] == "")
            {
                return "0" ;
            }
            return arr[ 0 , 0 ] ;
        }

        public string[,] getAllData() {            
            int i , a , b ;
            string where_clause_string_buildup , resultant_column_buildup , quo , sgn ;
            where_clause_string_buildup = "" ;
            resultant_column_buildup = "" ;
            if( this.where_clause_counter > 0 ) {
                where_clause_string_buildup = " where ";
            }      
            for( i = 0 ; i < this.where_clause_counter ; i++ ) {
                if( i != 0 ) {
                    where_clause_string_buildup += " and " ;
                }
                /*
                 * type 1 is like
                 * type 2 is less than
                 * type 3 is less than or equal
                 * type 4 is greater than
                 * type 5 is greater than or equal
                 * type 6 is exactly equal
                 * type 7 is not equal
                 * type 8 is IS comparator
                 */
                quo = "";
                sgn = "";
                if( this.where_clause_with_or_without_qoutation_flag[ i ] == true ) {
                    quo = "'";
                }
                if( this.where_clause_type_flag[ i ] == 1 ) {
                    where_clause_string_buildup += this.where_clause_key[ i ] + " like " + quo + "%" + this.where_clause_value[ i ] + "%" + quo + "";
                }
                else {
                    if( this.where_clause_type_flag[ i ] == 2 ) {
                        sgn = " < " ;
                    }
                    else if( this.where_clause_type_flag[ i ] == 3 ) {
                        sgn = " <= ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 4 ) {
                        sgn = " > ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 5 ) {
                        sgn = " >= ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 6 ) {
                        sgn = " = ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 7 ) {
                        sgn = " <> ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 8 ) {
                        sgn = " is ";
                    }
                    where_clause_string_buildup += this.where_clause_key[ i ] + sgn + quo + "" + this.where_clause_value[ i ] + "" + quo + "";
                }
            }
            if( this.resultant_columns_counter == 0 ) {
                resultant_column_buildup = " * ";
            }
            for( i = 0 ; i < this.resultant_columns_counter ; i++ ) {
                if( i != 0 ) {
                    resultant_column_buildup += " , " ;
                }
                resultant_column_buildup += this.resultant_columns[ i ] ;
            }
            string sql_buildup_result ;
            sql_buildup_result = "select " + this.limit_clause + resultant_column_buildup + " from " + this.class_name + where_clause_string_buildup + this.order_by_clause + " ; " ;
            //System.Windows.MessageBox.Show( sql_buildup_result ) ;
            string[ , ] arr = this.getDataTable( sql_buildup_result ) ;
            a = this.num_of_rows ;
            b = this.num_of_cols ;
            this.init() ;
            this.num_of_rows = a ;
            this.num_of_cols = b ;
            return arr ;
        }

        public void setWhereClause( string key , string value , int clause_type , bool with_or_without_quotation_flag ) {
            int a ;
            a = this.where_clause_counter ;
            this.where_clause_key[ a ] = key ;
            this.where_clause_value[ a ] = value ;
            this.where_clause_type_flag[ a ] = clause_type ;
            this.where_clause_with_or_without_qoutation_flag[ a ] = with_or_without_quotation_flag ;
            this.where_clause_counter++ ;
        }

        public void setUpdateSetClause(string key, string value, bool with_or_without_quotation_flag) {
            int a ;
            a = this.set_clause_counter ;
            this.set_clause_key[a] = key ;
            this.set_clause_value[a] = value ;
            this.set_clause_with_or_without_qoutation_flag[a] = with_or_without_quotation_flag ;
            this.set_clause_counter++ ;
        }

        public void setResultantColumn( string column_name_param ) {
            this.resultant_columns[ this.resultant_columns_counter++ ] = column_name_param ;
        }

        public void setLimit( int data_limit_param ) {
            this.limit_clause = " top " + data_limit_param + " " ;
        }

        protected void setOrderByAsc( string order_by_column_name ) {
            this.order_by_clause = " order by " + order_by_column_name + " asc " ;
        }

        protected void setOrderByDesc( string order_by_column_name ) {
            this.order_by_clause = " order by " + order_by_column_name + " desc " ;
        }

        public int getNumRows() {
            return this.num_of_rows ;
        }

        public int getNumCols() {
            return this.num_of_cols ;
        }

        protected string[,] getTableDetails() {
            int i , sz ;
            string[ , ] arr = this.getDataTable( "select * from information_schema.columns where table_name='" + this.class_name + "' ; " ) ;
            sz = this.getNumRows() ;
            this.column_size = 0 ;
            for( i = 0 ; i < sz ; i++ ) {                
                this.column_names[ this.column_size ] = arr[ i , 3 ] ;
                this.column_types[ this.column_size ] = arr[ i , 7 ] ;
                this.column_size++ ;
            }
            return arr ;
        }

        public string[] getAllColumns() {
            return this.column_names ;
        }

        public int getColumnSize() {
            return this.column_size ;
        }

        public string getParticularData( int row_idx , int col_idx ) {
            if( row_idx >= this.getNumRows() || col_idx >= this.getNumCols() ) {
                throw new ExceptionHandler( this.class_name , " index overflow in getParticularData() method." ) ;
            }
            return this.data[ row_idx , col_idx ] ;
        }
        
        public void insert( string[] arr ) {
            int i ;
            string key_value ;
            key_value = "" ;
            for( i = 0 ; i < this.column_size ; i++ ) {
                if( i != 0 ) {
                    key_value += " , " ;
                }
                if( this.column_types[ i ].CompareTo( "int" ) == 0 || arr[ i ].ToLower().CompareTo( "null" ) == 0 ) {
                    key_value += " " + arr[ i ] + " " ;
                }
                else {
                    key_value += " '" + arr[ i ] + "' " ;
                }
            }
            string local_query ;
            local_query = "insert into " + this.class_name + " values( " + key_value + " ) ;" ;
            //System.Windows.MessageBox.Show( local_query ) ;
            this.dc.execute( local_query ) ;
        }

        public void update() {
            int i , a , b;
            string where_clause_string_buildup , quo , sgn , set_column_buildup;
            where_clause_string_buildup = "";
            set_column_buildup = "";
            if( this.where_clause_counter > 0 ) {
                where_clause_string_buildup = " where ";
            }
            if( this.set_clause_counter > 0 ) {
                set_column_buildup = " set ";
            }
            for( i = 0 ; i < this.where_clause_counter ; i++ ) {
                if( i != 0 ) {
                    where_clause_string_buildup += " and ";
                }
                /*
                 * type 1 is like
                 * type 2 is less than
                 * type 3 is less than or equal
                 * type 4 is greater than
                 * type 5 is greater than or equal
                 * type 6 is exactly equal
                 * type 7 is not equal
                 * type 8 is IS comparator
                 */
                quo = "";
                sgn = "";
                if( this.where_clause_with_or_without_qoutation_flag[ i ] == true ) {
                    quo = "'";
                }
                if( this.where_clause_type_flag[ i ] == 1 ) {
                    where_clause_string_buildup += this.where_clause_key[ i ] + " like " + quo + "%" + this.where_clause_value[ i ] + "%" + quo + "";
                }
                else {
                    if( this.where_clause_type_flag[ i ] == 2 ) {
                        sgn = " < ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 3 ) {
                        sgn = " <= ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 4 ) {
                        sgn = " > ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 5 ) {
                        sgn = " >= ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 6 ) {
                        sgn = " = ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 7 ) {
                        sgn = " <> ";
                    }
                    else if( this.where_clause_type_flag[ i ] == 8 ) {
                        sgn = " is ";
                    }
                    where_clause_string_buildup += this.where_clause_key[ i ] + sgn + quo + "" + this.where_clause_value[ i ] + "" + quo + "";
                }
            }
            for( i = 0 ; i < this.set_clause_counter ; i++ ) {
                if( i != 0 ) {
                    set_column_buildup += " , ";
                }
                quo = "";
                if( this.set_clause_with_or_without_qoutation_flag[ i ] == true ) {
                    quo = "'";
                }
                set_column_buildup += " " + this.set_clause_key[ i ] + " = " + quo + this.set_clause_value[ i ] + quo + " ";
            }
            string sql_buildup_result;
            sql_buildup_result = "update " + this.class_name + set_column_buildup + where_clause_string_buildup + " ; ";
            //System.Windows.MessageBox.Show( sql_buildup_result ) ;
            this.dc.execute( sql_buildup_result );
            this.init();
        }
    }
}


