using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Data ;
using System.IO ;
using System.Windows.Controls ;
using System.Threading.Tasks ;
using iTextSharp.text ;
using iTextSharp.text.pdf ;
using iTextSharp.text.html ;
using iTextSharp.text.html.simpleparser ;

namespace FingerPrintScanner.src.controller {
    public class PdfHandler {
        private PdfHandler() {
        }

        public static void exportToPdf( DataGrid dgv ) {
            FileStream fs = new FileStream( "SearchResult.pdf" , FileMode.Create , FileAccess.Write , FileShare.None ) ;
            Document doc = new Document() ;
            PdfWriter writer = PdfWriter.GetInstance( doc , fs ) ;
            doc.Open() ;

            int noOfColumns , noOfRows , i , j ;
            noOfColumns = dgv.Columns.Count ;
            noOfRows = dgv.Items.Count ;
            System.Windows.MessageBox.Show( noOfColumns + "...." + noOfRows ) ;
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable( noOfColumns ) ;
            PdfPCell pcell = new PdfPCell() ;
            pcell.BackgroundColor = BaseColor.WHITE ;
            for( i = 0 ; i < noOfRows ; i++ ) {
                for( j = 0 ; j < noOfColumns ; j++ ) {
                    string cell_string_value ;
                    cell_string_value = ( dgv.Items[ i ] as DataRowView ).Row.ItemArray[ j ].ToString() ;
                    //propertyValue = GetPropertyValue( customers[ rowNo ] , columnNames[ columnNo ] ) ;
                    pcell = new PdfPCell( new Phrase( cell_string_value ) ) ;
                    pcell.BackgroundColor = BaseColor.WHITE ;
                    pcell.Colspan = 1 ;
                    pcell.HorizontalAlignment = 1 ;
                    table.AddCell( pcell ) ;
                }
            }


            doc.Add( table ) ;


            //doc.Add( new Paragraph( "Search Result Between" ) ) ;
            doc.Close() ;
        }
    }
}
