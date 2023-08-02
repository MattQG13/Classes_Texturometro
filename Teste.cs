using ClassesSuporteTexturometro;
using System.Collections.Generic;

namespace TesteTextuometro {

    public class CorpoDeProva{
       public double Deformação {get;}
       public double Altura {get; set;}
       public Tabela Resultado {get; set;}
     }

    public abstract class Teste {
        public TipoDeTeste Tipo { get; set; }
        public double VelAvancMotor { get; set; }
        public double VelRetornaMotor { get; set; }
        public Estado Step { get; set; }
        public List<Estado> Steps { get; set; } = new List<Estado>();

        public Estado Estado {
            get {
                return Step;
            }
        }
    }

    public sealed class TesteFactoryMethod {
        public static Teste criarTeste(TipoDeTeste tipo) {
            Teste teste;
            switch(tipo) {
                case TipoDeTeste.Compressao:
                    teste = new TesteCompressao();
                    break;
                case TipoDeTeste.Tracao:
                    teste=new TesteTracao();
                    break;
                case TipoDeTeste.CicloDuplo:
                    teste=new TesteCiclo();
                    break;
                default:
                    teste=null;
                    break;
            }
            return teste;
        }
    }

    public class TesteCompressao : Teste{

        public TesteCompressao(){
            Tipo=TipoDeTeste.Compressao;
            Steps = new List<Estado> {
                Estado.CargaMax,
                Estado.Parado,
                Estado.DeformacaMax
            };
        }
    }
    public class TesteTracao : Teste {

            public TesteTracao() {
                Tipo=TipoDeTeste.Tracao;
                Steps=new List<Estado> {
                Estado.CargaMax,
                Estado.Parado,
                Estado.DeformacaMax
            };
        }
    }
    public class TesteCiclo : Teste {
        public TesteCiclo() {
            Tipo=TipoDeTeste.CicloDuplo;
            Steps = new List<Estado> {
                Estado.CargaMax,
                Estado.Parado,
                Estado.DeformacaMax
            };
        }
    }
}