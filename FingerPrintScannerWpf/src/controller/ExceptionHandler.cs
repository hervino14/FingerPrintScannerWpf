using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Windows.Forms ;
using System.Threading.Tasks ;

namespace FingerPrintScanner.src.controller {
    public class ExceptionHandler : Exception {
        private ExceptionHandler() {
        }

        public ExceptionHandler( string class_name , string err_msg ) {
            MessageBox.Show( "Error occured in:" + class_name + " and the error message is:" + err_msg ) ;
        }
    }
}
