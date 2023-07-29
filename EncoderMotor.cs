using System;
using System.Diagnostics;

namespace EncoderMotor {
    public class Encoder {
        public EventHandler ValueChanged;
        public EventHandler ZeroSeated;

        private int PulsosPorRotacao;
        private int Puls;
        private double Rot;
        private double RotAnt;
        private double VelRot;
        private Stopwatch Timer = new Stopwatch();
        private long CurrentTime;
        private long PreviousTime;

        public Encoder(int PulsosPorRotacao) {
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

        public void Start() {
            Timer.Start();
            CurrentTime=Timer.ElapsedMilliseconds;
        }
        public void Stop() {
            Timer.Stop();
        }

        public void SetZero() {
            Rot=0;
            Puls=0;
            ZeroSeated.Invoke(this,EventArgs.Empty);
        }
    }
}