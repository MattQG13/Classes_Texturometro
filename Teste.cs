namespace Teste {
	
	public class Teste {
        private double VelAvancMotor;
        private double VelRetornaMotor;
        private Estado Step;

        private List<Estado> Tipo1 = new List<Estado> {
            Estado.CargaMax,
            Estado.Parado,
            Estado.DeformacaMax
        };
        private List<Estado> Tipo2 = new List<Estado> {
            Estado.CargaMax,
            Estado.Parado,
            Estado.DeformacaMax
        };
        private List<Estado> Tipo3 = new List<Estado> {
            Estado.CargaMax,
            Estado.Parado,
            Estado.DeformacaMax
        };
        private List<Estado> Tipo4 = new List<Estado> {
            Estado.CargaMax,
            Estado.Parado,
            Estado.DeformacaMax
        };

        public List<Estado> Steps = new List<Estado>();


        public Teste(int tipo) {
            switch(tipo) {
                case 1:
                    Steps=Tipo1;
                    break;
                case 2:
                    Steps=Tipo2;
                    break;
                case 3:
                    Steps=Tipo3;
                    break;
                case 4:
                    Steps=Tipo4;
                    break;
                default:
                    break;
            }
        }
        public Estado Estado {
            get {
                return Step;
            }
        }

    }
}