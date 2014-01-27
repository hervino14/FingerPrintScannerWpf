using System ;
using System.Threading.Tasks ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Data ;
using System.Drawing ;
using System.Text ;
using System.IO.Ports ;
using System.Threading ;
using System.Text.RegularExpressions ;
using System.Windows.Forms ;
using System.IO ;

namespace FingerPrintScanner.src.controller {
    public class ComportController {
        private SerialPort _serialPort = new SerialPort();
        private int _baudRate = 9600;
        private int _dataBits = 8;
        private Handshake _handshake = Handshake.None;
        private Parity _parity = Parity.None;
        private string _portName = "COM4";
        private StopBits _stopBits = StopBits.One;
        private long prev_miliseconds , prev_id;
        /// <summary> 
        /// Holds data received until we get a terminator. 
        /// </summary> 
        private string tString = string.Empty;
        /// <summary> 
        /// End of transmition byte in this case EOT (ASCII 4). 
        /// </summary> 
        private byte _terminator = 0x4;

        public ComportController() {
            this.prev_miliseconds = -1;
            this.prev_id = -1;
        }
        public int BaudRate {
            get {
                return _baudRate;
            }
            set {
                _baudRate = value;
            }
        }
        public int DataBits {
            get {
                return _dataBits;
            }
            set {
                _dataBits = value;
            }
        }
        public Handshake Handshake {
            get {
                return _handshake;
            }
            set {
                _handshake = value;
            }
        }
        public Parity Parity {
            get {
                return _parity;
            }
            set {
                _parity = value;
            }
        }
        public string PortName {
            get {
                return _portName;
            }
            set {
                _portName = value;
            }
        }
        public bool startListening() {
            try {
                _serialPort.BaudRate = _baudRate;
                _serialPort.DataBits = _dataBits;
                _serialPort.Handshake = _handshake;
                _serialPort.Parity = _parity;
                _serialPort.PortName = _portName;
                _serialPort.StopBits = _stopBits;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler( _serialPort_DataReceived );
                _serialPort.Open();
                //MessageBox.Show("Connected Successfully!");
            }
            catch {
                //throw new ExceptionHandler( "ComPortController" , "Error in initializing COM port!" ) ;
                MessageBox.Show( "Error in initializing COM port!" ) ;
                return false ;
            }
            return true;
        }
        private int parseData( String s ) {
            int i , len , a , res ;
            String t ;
            t = "" ;
            len = s.Length ;
            a = len - 3 ;
            for( i = len - 1 ; i >= 0 ; i-- ) {
                if( ( s[ i ] >= 'a' && s[ i ] <= 'z' ) || ( s[ i ] >= 'A' && s[ i ] <= 'Z' ) || ( s[ i ] >= '0' && s[ i ] <= '9' ) || s[ i ] == ':' ) {
                }
                else {
                    continue ;
                }
                if( ! ( s[ i ] >= '0' && s[ i ] <= '9' ) ) {
                    break ;
                }
                a = i ;
            }
            for( i = a ; i < len ; i++ ) {
                t += s[ i ] ;
            }
            res = Int32.Parse( t ) ;
            return res ;
        }
        void _serialPort_DataReceived( object sender , SerialDataReceivedEventArgs e ) {
            String message_output ;
            message_output = "" ;
            //message_output += "Buffer Size: " + _serialPort.ReadBufferSize ;
            //message_output += "\n"  ;
            //Initialize a buffer to hold the received data 
            byte[] buffer = new byte[ _serialPort.ReadBufferSize ];

            //There is no accurate method for checking how many bytes are read 
            //unless you check the return from the Read method 
            int bytesRead = _serialPort.Read( buffer , 0 , buffer.Length );
            //message_output += "Bytes Read: " + bytesRead;
            //message_output += "\n";            

            //For the example assume the data we are received is ASCII data. 
            tString += Encoding.ASCII.GetString( buffer , 0 , bytesRead );
            int a;
            a = -1;
            //MessageBox.Show( "..." + tString + "...." );
            if( tString != null && tString.CompareTo( "" ) != 0 && tString.CompareTo( "-1" ) != 0 ) {
                long current = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond ;
                try {
                    a = this.parseData( tString ) ;
                }
                catch( Exception exp ) {
                    throw new ExceptionHandler( "ComPortController" , exp.ToString() ) ;
                }
                if( ( this.prev_miliseconds == -1 || current - this.prev_miliseconds > 3000 || this.prev_id != a ) && a != -1 ) {
                    //MessageBox.Show( "--------" + tString + "--------" );
                    //MessageBox.Show( "The User Id is: " + a );
                    UserEntryHandler ueh = new UserEntryHandler();
                    ueh.insertEntryToTable( a.ToString() , DateTime.Now.ToString( "dd-MMM-yyyy HH:mm:ss tt" ) );
                    tString = "";
                    this.prev_miliseconds = current;
                    this.prev_id = a;    
                }                
            }
            //message_output += "tString variable data: " + tString;
            //message_output += "\n";         
            //MessageBox.Show(message_output);
            //Check if string contains the terminator  
            if( tString.IndexOf( ( char ) _terminator ) > -1 ) {
                //If tString does contain terminator we cannot assume that it is the last character received 
                string workingString = tString.Substring( 0 , tString.IndexOf( ( char ) _terminator ) );
                //Remove the data up to the terminator from tString 
                tString = tString.Substring( tString.IndexOf( ( char ) _terminator ) );
                //Do something with workingString 
                Console.WriteLine( workingString );
            }
        }

        /// Closes the serial port
        public void stopListening() {
            _serialPort.Close();
        }
    }
}
