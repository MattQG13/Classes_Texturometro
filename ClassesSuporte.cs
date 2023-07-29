using System;
using System.Collections.Generic;

namespace ClassesSuporteTexturometro {
	public enum Estado {
        Parado,
        CargaMax,
        DeformacaMax
    };
    public enum TipoDeTeste {
        Compressao,
        Tracao,
        CicloDuplo
    };

    public class SerialMessageArgument : EventArgs {
        public string Objeto {
            get; set;
        }
        public string Comando {
            get; set;
        }
        public double doubleValue {
            get; set;
        }
        public bool boolValue {
            get; set;
        }
        public int intValue {
            get; set;
        }
    }
    /*public class SensorArgumento: EventArgs {
		public string Objeto;
		public string Comando;
		public double doubleValue;
		public bool boolValue;
		public int intValue;
	}
	*/
    public class Chave {
        private bool state;
        public EventHandler ValueChanged;

        public Chave() {
            state=false;
        }

        public bool Estado {
            get {
                return state;
            }
            set {
                state=value;
                ValueChanged.Invoke(this,EventArgs.Empty);
            }
        }
    }

    public class Coord {
        public double X { get; set; }
        public double Y { get; set; }

        public Coord() {
            X=0;
            Y=0;
        }
        public Coord(double X,double Y) {
            this.X=X;
            this.Y=Y;
        }
    }
    public class Tabela {
        private List<Coord> Table = new List<Coord>();

        public void Add(double x,double y) {
            Table.Add(new Coord(x,y));
        }

        public void Add(Coord xy) {
            Table.Add(xy);
        }

        public List<double> GetXvalues() {
            List<double> list = new List<double>();
            foreach(var x in Table) {
                list.Add(x.X);
            }
            return list;
        }

        public List<double> GetYvalues() {
            List<double> list = new List<double>();
            foreach(var y in Table) {
                list.Add(y.Y);
            }
            return list;
        }

    }
    public class StaticFunc { }
}