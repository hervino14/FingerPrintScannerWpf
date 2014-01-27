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
using FingerPrintScanner.src.view ;

namespace FingerPrintScanner.src.view {
    /// <summary>
    /// First xaml(the landing one) of the user interface
    /// </summary>
    public partial class ControlPanel : Window {
        private int xaml_state , number_of_xaml_states ;
        private XamlEntityDesigner xed ;        

        public ControlPanel() {
            InitializeComponent() ;
            this.init() ;
        }

        private void init() {            
            int i ;
            this.xaml_state = 0 ;
            this.number_of_xaml_states = 5 ;            
            this.xed = new XamlEntityDesigner( this.main_grid , this ) ;
            this.initializeAllStates() ;
            this.initializeScreen() ;
        }        

        private void initializeScreen() {
            this.WindowState = System.Windows.WindowState.Maximized ;            
            this.main_grid.VerticalAlignment = VerticalAlignment.Top ;
            this.main_grid.HorizontalAlignment = HorizontalAlignment.Left;
        }

        private void initializeAllStates() {
            this.initializeStageOne() ;
            //this.initializeStageTwo() ;            
        }

        private void initAllStages() {
            this.xed.clearAllChildren() ;
        }

        private void initializeStageOne() {
            this.initAllStages() ;
            this.xed.addNewButton( "Login to Admin Dashboard!" , 500 , 300 , 2 ) ;
        }

        private void initializeStageTwo() {
            this.initAllStages() ;
            this.xed.addNewTextBlock( "User Name: " , 400 , 245 ) ;
            this.xed.addNewTextBlock( "Password: " , 400 , 295 ) ;
            this.xed.addNewTextBox( "user_name" , 500 , 100 ) ;
            this.xed.addNewPasswordBox( "password" , 500 , 200 );            
            this.xed.addNewButton( "Login!" , 500 , 350 , 3 ) ;
        }

        private void initializeStageThree() {
            this.initAllStages();
            this.xed.addNewTextBlock( "Start Time: " , 50 , 10 ) ;
            this.xed.addNewTextBlock( "End Time: " , 500 , 10 ) ;
            this.xed.addNewButton( "Admin Panel" , 1100 , -300 , 4 ) ;
            this.xed.addNewButton( "Search!" , 200 , 50 , 3 ) ;
            this.xed.addNewDataGridView( "dg1" , 100 , 200 ) ;
        }

        private void initializeStageFour() {
        }

        public void makeStateTransition( int state ) {
            if( state == 1 ) {
                this.initializeStageOne() ;
            }
            else if( state == 2 ) {
                this.initializeStageTwo() ;                
            }
            else if( state == 3 ) {
                this.initializeStageThree() ;
            }
            else if( state == 3 ) {
                this.initializeStageFour();
            }
        }

        public void goToNextState() {

        }

        public void stateOne() {            
        }
    }
}
