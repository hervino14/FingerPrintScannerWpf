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

    public class XamlEntityDesigner {
        private TextBox[] tbo;
        private PasswordBox[] pbo;
        private TextBlock[] tbl;
        private Button[] brr;
        private DatePicker[] dtp ;
        private DataGrid[] dgv ;
        private int tbox_cn , tblock_cn , btn_cn , dtp_cn , pbo_cn , dgv_cn ;
        private Grid grd;
        private ControlPanel cp ;

        private XamlEntityDesigner() {            
        }

        public XamlEntityDesigner( Grid grd_param , ControlPanel cp_param ) {
            this.cp = cp_param ;
            this.grd = grd_param ;
            this.init() ;
        }

        private void init() {
            this.tbo = new TextBox[ EnvironmentVariableHandler.getArrayLimit() ] ;            
            this.pbo = new PasswordBox[ EnvironmentVariableHandler.getArrayLimit() ] ;
            this.tbl = new TextBlock[ EnvironmentVariableHandler.getArrayLimit() ] ;
            this.brr = new Button[ EnvironmentVariableHandler.getArrayLimit() ] ;
            this.dtp = new DatePicker[ EnvironmentVariableHandler.getArrayLimit() ] ;
            this.dgv = new DataGrid[ EnvironmentVariableHandler.getArrayLimit() ] ;
            this.tbox_cn = 0 ;
            this.tblock_cn = 0 ;
            this.btn_cn = 0 ;
            this.dtp_cn = 0 ;
            this.pbo_cn = 0 ;
            this.dgv_cn = 0 ;
        }

        protected void buttonClicked( object sender , RoutedEventArgs e ) {            
            int local_state ;
            Button local_btn ;            
            local_btn = ( Button ) sender ;
            local_state = Int32.Parse( local_btn.CommandParameter.ToString() ) ;
            if( local_state == 1 ) {
                this.cp.makeStateTransition( 1 ) ;
            }
            else if( local_state == 2 ) {
                this.cp.makeStateTransition( 2 );
            }
            else if( local_state == 3 ) {
                UserHandler uh ;
                int res ;
                uh = new UserHandler() ;                
                res = uh.checkAdmin( this.tbo[ 0 ].Text , this.pbo[ 0 ].Password ) ;
                if( res == 1 ) {
                    this.cp.makeStateTransition( 3 ) ;
                }
                else {
                    if( res == 2 ) {
                        MessageBox.Show( "Please Provide a User Name!" ) ;
                    }
                    else if( res == 3 ) {
                        MessageBox.Show( "Please Provide Your Password!" ) ;
                    }
                    else if( res == 4 ) {
                        MessageBox.Show( "Wrong Username Password Combination!" ) ;
                    }
                    this.cp.makeStateTransition( 2 ) ;
                }
            }
        }

        public void addNewButton( string btn_name , int x , int y , int state_to_transit_after_being_clicked ) {
            this.brr[ this.btn_cn ] = new Button() ;
            this.brr[ this.btn_cn ].Content = btn_name ;
            Thickness tn = new Thickness() ;
            tn.Left =  x ;
            tn.Bottom = 10 ;
            tn.Right = 0 ;
            tn.Top = y ;
            this.brr[ this.btn_cn ].Margin = tn ;
            this.brr[ this.btn_cn ].Width = ElementInformationHolder.getButtonWidth() ;
            this.brr[ this.btn_cn ].Height = ElementInformationHolder.getButtonHeight() ;
            this.brr[ this.btn_cn ].FontSize = ElementInformationHolder.getFontSize() ;
            this.brr[ this.btn_cn ].FontFamily = ElementInformationHolder.getFontFamily() ;
            this.brr[ this.btn_cn ].CommandParameter = state_to_transit_after_being_clicked.ToString() ;
            this.brr[ this.btn_cn ].Click += this.buttonClicked ;
            this.grd.Children.Add( this.brr[ this.btn_cn ] ) ;
            this.btn_cn++ ;            
        }        

        public void addNewTextBox( string tb_name , int x , int y ) {
            this.tbo[ this.tbox_cn ] = new TextBox() ;
            this.tbo[ this.tbox_cn ].Name = tb_name ;
            Thickness tn = new Thickness() ;
            tn.Left = x ;
            tn.Bottom = 10 ;
            tn.Right = 0 ;
            tn.Top = y ;
            this.tbo[ this.tbox_cn ].Margin = tn;
            this.tbo[ this.tbox_cn ].Width = ElementInformationHolder.getTextBoxWidth();
            this.tbo[ this.tbox_cn ].Height = ElementInformationHolder.getTextBoxHeight();
            this.tbo[ this.tbox_cn ].FontSize = ElementInformationHolder.getFontSize();
            this.tbo[ this.tbox_cn ].FontFamily = ElementInformationHolder.getFontFamily();            
            this.grd.Children.Add( this.tbo[ this.tbox_cn ] );
            this.tbox_cn++;
        }

        public void addNewPasswordBox( string tb_name , int x , int y ) {
            this.pbo[ this.pbo_cn ] = new PasswordBox();
            this.pbo[ this.pbo_cn ].Name = tb_name;
            Thickness tn = new Thickness();
            tn.Left = x;
            tn.Bottom = 10;
            tn.Right = 0;
            tn.Top = y;
            this.pbo[ this.pbo_cn ].Margin = tn;
            this.pbo[ this.pbo_cn ].Width = ElementInformationHolder.getTextBoxWidth();
            this.pbo[ this.pbo_cn ].Height = ElementInformationHolder.getTextBoxHeight();
            this.pbo[ this.pbo_cn ].FontSize = ElementInformationHolder.getFontSize();
            this.pbo[ this.pbo_cn ].FontFamily = ElementInformationHolder.getFontFamily();
            this.grd.Children.Add( this.pbo[ this.pbo_cn ] );
            this.tbox_cn++;
        }

        public void addNewTextBlock( string tbl_name , int x , int y ) {
            this.tbl[ this.tblock_cn ] = new TextBlock() ;            
            this.tbl[ this.tblock_cn ].Text = tbl_name ;
            Thickness tn = new Thickness() ;
            tn.Left = x ;
            tn.Bottom = 10 ;
            tn.Right = 0 ;
            tn.Top = y ;
            this.tbl[ this.tblock_cn ].Margin = tn ;            
            this.tbl[ this.tblock_cn ].FontSize = ElementInformationHolder.getFontSize() ;
            this.tbl[ this.tblock_cn ].FontFamily = ElementInformationHolder.getFontFamily() ;
            this.grd.Children.Add( this.tbl[ this.tblock_cn ] ) ;
            this.tblock_cn++ ;
        }

        public void addNewDataGridView( string grd_name , int x , int y ) {
            this.dgv[ this.dgv_cn ] = new DataGrid() ;            
            Thickness tn = new Thickness() ;
            tn.Left = x ;
            tn.Bottom = 0 ;
            tn.Right = 0 ;
            tn.Top = y ;
            this.dgv[ this.dgv_cn ].Margin = tn ;            
            this.dgv[ this.dgv_cn ].FontSize = ElementInformationHolder.getFontSize() ;
            this.dgv[ this.dgv_cn ].FontFamily = ElementInformationHolder.getFontFamily() ;
            this.dgv[ this.dgv_cn ].Visibility = Visibility.Visible ;
            this.grd.Children.Add( this.dgv[ this.dgv_cn ] ) ;
            this.dgv_cn++ ;
        }
        public void clearAllChildren() {
            int i , sz ;            
            sz = this.grd.Children.Count ;            
            for( i = sz - 1 ; i >= 0 ; i-- ) {
                this.grd.Children.RemoveAt( i ) ;
            }
            this.init() ;
        }
    }
}

