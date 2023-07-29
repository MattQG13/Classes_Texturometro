using EncoderMotor;
using System;

namespace MotorTexturometro {
	public class Motor {
		private double Passo;
		private double SPVel;
		private int ModoOper;
		private Encoder EncoderMotor;

		public EventHandler SPVelChanged;

		public Motor(double PassoDoEixo, Encoder encoder) {
			EncoderMotor = encoder;
			Passo = PassoDoEixo;
		}

		public double VelocidadeRotacional {
			get {
				return EncoderMotor.Velocidade;
			}
		}

		public double VelocidadeLinear {
			get {
				return EncoderMotor.Velocidade*Passo;
			}
		}

		public double Posicao {
			get {
				return EncoderMotor.Rotacoes*Passo;
			}
		}

        public void Start(double velocidade, int modo) {
			SPVel = velocidade;
			ModoOper = modo;
		}

		public void ChangeVel(double velocidade) {
			SPVel = velocidade;
            SPVelChanged.Invoke(this,EventArgs.Empty);
        }

		public void ChangeDirection(int modo) {
			ModoOper = modo;
		}
	}

}