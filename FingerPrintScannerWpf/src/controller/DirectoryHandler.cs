using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.Windows.Forms ;

namespace FingerPrintScanner.src.controller {
    public sealed class DirectoryHandler {
        private DirectoryHandler() {
        }

        public static string getApplicationDirectory() {
            int i , len , j , k ;
            string s , t , res ;
            s = Environment.CurrentDirectory ;            
            len = s.Length ;
            k = len - 1 ;
            res = "" ;
            for( i = 0 ; i < len ; i++ ) {
                t = "";
                for( j = i ; j < Math.Min( len , i + 6 ) ; j++ ) {
                    t += s[ j ] ;
                }      
                t = t.ToLower() ;
                if( t.CompareTo( "\\debug" ) == 0 ) {
                    k = i ;
                    break ;
                }
            }
            for( i = 0 ; i < k ; i++ ) {
                t = "";
                for( j = i ; j < Math.Min( len , i + 4 ) ; j++ ) {
                    t += s[ j ];
                }                
                t = t.ToLower() ;                
                if( t.CompareTo( "\\bin" ) == 0 ) {
                    k = i ;
                    break;
                }
            }
            for( i = 0 ; i < k ; i++ ) {
                res += s[ i ] ;
            }
            return res ;
        }
    }
}
