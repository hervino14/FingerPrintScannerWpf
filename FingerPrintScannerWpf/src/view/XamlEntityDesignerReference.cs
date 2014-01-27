using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FingerPrintScanner.src.view;
using FingerPrintScanner.src.controller;

namespace FingerPrintScanner.src.view {
    public class XamlEntityDesignerReference {
        private XamlEntityDesignerReference() {
        
        }

        public static void designNewButton( string btn_name , Button btn_param ) {
            btn_param.Content = btn_name;
            btn_param.Width = ElementInformationHolder.getButtonWidth();
            btn_param.Height = ElementInformationHolder.getButtonHeight();
            btn_param.FontSize = ElementInformationHolder.getFontSize();
            btn_param.FontFamily = ElementInformationHolder.getFontFamily();            
        }

        public static void designNewLabel( string lbl_name , Label lbl_param ) {
            lbl_param.Content = lbl_name;
            lbl_param.Width = ElementInformationHolder.getTextBoxWidth();
            lbl_param.Height = ElementInformationHolder.getTextBoxHeight();
            lbl_param.FontSize = ElementInformationHolder.getFontSize();
            lbl_param.FontFamily = ElementInformationHolder.getFontFamily();
        }

        public static void designNewTextBox( TextBox tb_param ) {
            tb_param.Text = "";
            tb_param.Width = ElementInformationHolder.getTextBoxWidth();
            tb_param.Height = ElementInformationHolder.getTextBoxHeight();
            tb_param.FontSize = ElementInformationHolder.getFontSize();
            tb_param.FontFamily = ElementInformationHolder.getFontFamily();            
        }

        public static void designNewPasswordBox( PasswordBox pbox_param ) {
            pbox_param.Width = ElementInformationHolder.getTextBoxWidth();
            pbox_param.Height = ElementInformationHolder.getTextBoxHeight();
            pbox_param.FontSize = ElementInformationHolder.getFontSize();
            pbox_param.FontFamily = ElementInformationHolder.getFontFamily();            
        }

        public static void designNewDataGrid( DataGrid dgrid_param ) {
            dgrid_param.Width = ElementInformationHolder.getDataGridWidth();
            dgrid_param.Height = ElementInformationHolder.getDataGridHeight();
            dgrid_param.FontSize = ElementInformationHolder.getFontSize();
            dgrid_param.FontFamily = ElementInformationHolder.getFontFamily();
            dgrid_param.CanUserAddRows = false;
            dgrid_param.CanUserDeleteRows = false;
        }

        public static void designNewMenu( Menu menu_param ) {            
            menu_param.FontSize = ElementInformationHolder.getFontSize();
            menu_param.FontFamily = ElementInformationHolder.getFontFamily();            
        }
    }
}
