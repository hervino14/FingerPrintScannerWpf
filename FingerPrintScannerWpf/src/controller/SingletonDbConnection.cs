using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintScanner.src.controller {
    public sealed class SingletonDbConnection : DbConnection {
        private static DbConnection DC = new DbConnection() ;
        private SingletonDbConnection() {
        }

        public static DbConnection getInstance() {
            return DC ;
        }
    }
}
