namespace EncoderMotor {
	public class EncoderMotor {
        public EventHandler ValueChanged;

        private int PulsosPorRotacao;
        private int Puls;
        private double Rot;
        private double RotAnt;
        private double VelRot;
        private Stopwatch Timer = new Stopwatch();
        private long CurrentTime;
        private long PreviousTime;

        public EncoderMotor(int PulsosPorRotacao) {
            this.PulsosPorRotacao=PulsosPorRotacao;
            CurrentTime=0;
        }
        public int Pulsos {
            get {
                return Puls;
            }
            set {
                Puls=value;
                onPulseChange();
            }
        }

        private void onPulseChange() {
            PreviousTime=CurrentTime;
            CurrentTime=Timer.ElapsedMilliseconds;

            RotAnt=Rot;
            Rot=(double)Puls/(double)PulsosPorRotacao;

            VelRot=(RotAnt-Rot)/((int)(CurrentTime-PreviousTime));

            ValueChanged.Invoke(this,EventArgs.Empty);
        }

        public double Rotacoes {
            get {
                return Rot;
            }
        }

        public double Velocidade {
            get {
                return VelRot;
            }
        }

        public void TimerStart() {
            Timer.Start();
        }
        public void TimerStop() {
            Timer.Stop();
        }

        public void SetZero() {
            Rot=0;
            Puls=0;
            //retornar pro Arduino
        }
    }
}