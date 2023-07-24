namespace LoadCell {
	public class LoadCell {
		// Events → Set load

		private double Scale = 0xFFFFFF;
		private double CargaMax;
		private double Val;
		private const double g = 9.81;

		public LoadCell(int valorMax, int escala) {
			CargaMax = (double)valorMax;
			Scale = (double)escala;
		}

		public int ValorLoad {
			get {
				return (int)Math.Round(Val);
			}
			set {
				Val = (double)value;
			}
		}

		public double cargaKg {
			get {
				return (Val*CargaMax)/Scale;
			}
		}

		public double cargaG {
			get {
				return (Val*CargaMax)/(Scale*1000d);
			}
		}

		public double cargaN {
			get {
				return (Val*CargaMax*g)/Scale;
			}
		}

	}
}