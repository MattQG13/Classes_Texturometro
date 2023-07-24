namespace SerialManager{
public class SerialManager {
        private SerialPort serialPort;
        public EventHandler<SerialMessageArgument> MessageInterpreted;

        public SerialManager(string portName,int baudRate) {
            serialPort=new SerialPort(portName,baudRate);
            serialPort.DataReceived+=DataReceived;
        }

        public SerialManager(string portName) {
            serialPort=new SerialPort(portName,115200);
            serialPort.DataReceived+=DataReceived;
        }
        public SerialManager() {
            serialPort=new SerialPort();
            serialPort.DataReceived+=DataReceived;
        }
        #region SerialPort

        public void SetCOM (string portName,int baudRate) {
            serialPort.PortName=portName;
            serialPort.BaudRate=baudRate;
        }
        public void SetCOM(string portName) {
            serialPort.PortName=portName;
        }

        public void SetCOM(int baudRate) {
            serialPort.BaudRate=baudRate;
        }

        public bool IsOpen {
            get {
                return serialPort.IsOpen;
            }
        }

        public bool DiscardNull {
            get {
                return serialPort.DiscardNull;
            }
            set {
                serialPort.DiscardNull=value;
            }
        }

        public void Open() {
            serialPort.Open();
        }

        public void Close() {
            serialPort.Close();
        }

        public void Write(string message) {
            serialPort.Write(message);
        }

        private void DataReceived(object sender,SerialDataReceivedEventArgs e) {
            string mensagem = serialPort.ReadTo("\r");
            string[] partesDaMensagem = ProcessaSerial(mensagem);
            InterpretaMensagem(partesDaMensagem);
        }
        #endregion

        private static string[] ProcessaSerial(string mensagem) {
            mensagem=mensagem.Replace("[",string.Empty).Replace("]",string.Empty);
            string[] partes = mensagem.Split(';');
            return partes;
        }

        private void InterpretaMensagem(string[] partesDaMensagem) {
            //chama os eventos
            SerialMessageArgument args = new SerialMessageArgument();
            args.Objeto=partesDaMensagem[0];

            switch(partesDaMensagem.Length) {
                case 2: //Load cell ou Encoder
                    if(args.Objeto=="LS"||args.Objeto=="LI") {
                        args.boolValue=partesDaMensagem[1]=="1" ? true : false;
                    }
                    if(args.Objeto=="E"||args.Objeto=="L") {
                        args.intValue=int.Parse(partesDaMensagem[1]);
                    }
                    break;
                case 3: //Motor X
                    args.Comando=partesDaMensagem[1];
                    args.doubleValue=double.Parse(partesDaMensagem[2]);
                    break;
                default:
                    break;
            }
            MessageInterpreted.Invoke(this,args);
        }
        public void EnvComandoMotor(int comando,int valor) { }
    }
}