using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.IO ;
using System.Drawing ;
using System.IO.Ports ;
using System.Threading ;
using System.Text.RegularExpressions ;
using System.Windows.Forms ;

namespace FingerPrintScanner.src.controller {
    public class ModelGenerator {
        private StreamWriter file_var ;
        private string data , directory_path , namespace_path , model_path , class_name ;
        public ModelGenerator( string file_name , string class_name_param ) {
            this.directory_path = DirectoryHandler.getApplicationDirectory() ;
            this.namespace_path = "AmassFingerPrintScanner.classes.controller" ;
            this.model_path = "\\classes\\model\\" ;
            this.class_name = class_name_param ;
            this.file_var = new StreamWriter( this.directory_path + this.model_path + file_name ) ;
            this.data = "" ;
        }

        private void buildData() {
            this.data += "" ;
            this.data += "using System ;" ;
            this.data += "\n" ;
            this.data += "using System.Collections.Generic ;" ;
            this.data += "\n" ;
            this.data += "using System.Linq ;" ;
            this.data += "\n" ;
            this.data += "using System.Text ;" ;
            this.data += "\n" ;
            this.data += "using System.Threading.Tasks ;" ;
            this.data += "\n" ;
            this.data += "using System.IO ;" ;
            this.data += "\n" ;
            this.data += "using System.Drawing ;" ;
            this.data += "\n" ;
            this.data += "using System.IO.Ports ;" ;
            this.data += "\n" ;
            this.data += "using System.Threading ;" ;
            this.data += "\n" ;
            this.data += "using System.Text.RegularExpressions ;" ;
            this.data += "\n" ;
            this.data += "using System.Windows.Forms ;" ;
            this.data += "\n" ;
            this.data += "\n" ;
            this.data += "namespace " + this.namespace_path + " {" ;
            this.data += "\n" ;
            this.data += "\n" ;
            this.data += "    public class " + this.class_name + " {" ;
            this.data += "\n" ;
            this.data += "    public class " + this.class_name + " {" ;
        }

        private void writeToFile() {
            this.file_var.WriteLine( this.data ) ;
            this.file_var.Close() ;
        }
    }
}
