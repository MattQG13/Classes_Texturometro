namespace Motor {
	public class Motor {
		private double Passo;
		private double SPVel;
		private int ModoOper;
		private EncoderMotor Encoder;

		public Motor(double PassoDoEixo) {
			Passo = PassoDoEixo;
		}

		//public SetValues(double Modo,double VelLin,int PulsosPorRotacao,)


		public double VelocidadeRotacional {
			get {
				return Encoder.Velocidade;
			}
		}

		public double VelocidadeLinear {
			get {
				return Encoder.Velocidade*Passo;
			}
		}

		public double Posicao {
			get {
				return Encoder.Rotacoes*Passo;
			}
		}
		public void Start(double velocidade, int modo) {
			SPVel = velocidade;
			ModoOper = modo;
		}

		public void ChangeVel(double velocidade) {
			SPVel = velocidade;
		}

		public void ChangeDirection(int modo) {
			ModoOper = modo;
		}

		private void autoControle() {
			//Controle de velocidade
		}
	}

}