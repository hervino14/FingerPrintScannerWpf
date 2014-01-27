﻿using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.Security.Cryptography ;

namespace FingerPrintScanner.src.controller {
    sealed public class Encryption {
        private Encryption() {
            
        }

        public static string calculateMD5Hash( string input ) {
            MD5 md5 = System.Security.Cryptography.MD5.Create() ;
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes( input ) ;
            byte[] hash = md5.ComputeHash( inputBytes ) ;
            StringBuilder sb = new StringBuilder() ;
            for( int i = 0 ; i < hash.Length ; i++ ) {
                sb.Append( hash[ i ].ToString( "X2" ) ) ;
            }
            return sb.ToString() ;
        }
    }
}
