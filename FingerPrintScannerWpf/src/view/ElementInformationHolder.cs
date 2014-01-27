using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.Windows ;
using System.Windows.Controls ;
using System.Windows.Data ;
using System.Windows.Documents ;
using System.Windows.Input ;
using System.Windows.Media ;
using System.Windows.Media.Imaging ;
using System.Windows.Navigation ;
using System.Windows.Shapes ;
using FingerPrintScanner.src.controller ;
using FingerPrintScanner.src.model ;
using FingerPrintScanner.src.view ;

namespace FingerPrintScanner.src.view {
    sealed public class ElementInformationHolder {
        private static int font_size ;
        private static FontFamily font_family ;
        private static int button_width , button_height , textbox_width , textbox_height , textblock_width , textblock_height , datagrid_width , datagrid_height , menu_width , menu_height ;

        private ElementInformationHolder() {
        }

        private static void init() {
            ElementInformationHolder.font_size = 12 ;
            ElementInformationHolder.font_family = new FontFamily( "Calibri" ) ;
            ElementInformationHolder.button_height = 40 ;
            ElementInformationHolder.button_width = ( int ) ( 4.75 * ( double ) ElementInformationHolder.button_height ) ;
            ElementInformationHolder.textbox_height = 30 ;
            ElementInformationHolder.textbox_width = 400 ;
            ElementInformationHolder.textblock_height = 30 ;
            ElementInformationHolder.textblock_width = 400 ;
            ElementInformationHolder.datagrid_height = 355 ;
            ElementInformationHolder.datagrid_width = 944 ;
            ElementInformationHolder.menu_height = 10;
            ElementInformationHolder.menu_width = 10;
        }

        public static int getFontSize() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.font_size ;
        }

        public static FontFamily getFontFamily() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.font_family ;
        }

        public static int getButtonWidth() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.button_width ;
        }

        public static int getButtonHeight() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.button_height ;
        }

        public static int getTextBoxWidth() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.textbox_width ;
        }

        public static int getTextBoxHeight() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.textbox_height ;
        }

        public static int getDataGridWidth() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.datagrid_width ;
        }

        public static int getDataGridHeight() {
            ElementInformationHolder.init() ;
            return ElementInformationHolder.datagrid_height;
        }

        public static int getMenuWidth() {
            ElementInformationHolder.init();
            return ElementInformationHolder.menu_width;
        }

        public static int getMenuHeight() {
            ElementInformationHolder.init();
            return ElementInformationHolder.menu_height;
        }
    }
}
