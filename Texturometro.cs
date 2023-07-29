/*
* Nome do Arquivo: Classes.cs
* Autor: Mateus Quintino
* Data de Início: 01/07/2023
* Descrição: Este código possui classes para serem usadas
* no controlador do texturômetro desenvolvido para projeto de TCC
*
* Notas:
* - Padrão de estrutura de protocolo [L;valor] [E;valor] [LS;valor] [LI;valor] [M;comando;valor]
*     - L de Load Cell, E de Encoder, M de Motor, LS de limite superior, LI de limite inferior
* - Os comandos do motor podem ser RH, RA ou S
*     - RH de Rotação horária, RA de Rotação Anti-horária e S de Stop
*/

using ClassesSuporteTexturometro;
using LoadCellTexturometro;
using MotorTexturometro;
using SerialManagerTexturometro;
using System;
using System.Windows.Forms;
using TesteTextuometro;

namespace TexturometroClass {
	/*
	*Zerar Célula de Carga
	*Zerar Encoder
	*Teste
	*Exportar resultados 
	*/
	public class Texturometro {
		public Motor Motor;
		public Chave SensorLS;
		public Chave SensorLI;
        public static LoadCell CelulaDeCarga;
        public Teste DadosDoTeste;
		public SerialManager Serial = new SerialManager();
		public Tabela Resultado = new Tabela();

		public Texturometro() {
			DadosDoTeste = TesteFactoryMethod.criarTeste(TipoDeTeste.Compressao);
            Serial.MessageInterpreted+=AtualizaSensores;
		}

		private void Texturometro_Load(object sender, EventArgs e) {
			try {
				//Serial.SetCOM(Properties.Settings.Default.cfgPortaCOM);

				if (Serial.IsOpen == true) {
					Serial.Close();
				}
				Serial.DiscardNull = true;
				Serial.Open();
			} catch {
				MessageBox.Show("Porta COM não encontrada!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			// Busca configurações no sistema
			/*try  {

            } finally { }*/
		}

		private void IniciarTeste_Click(object sender, EventArgs e) {}

		public void Teclado_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.Up:
				case Keys.NumPad8:
					//Ativa motor pra cima
					break;
				case Keys.Down:
				case Keys.NumPad2:
					//Ativa motor pra baixo
					break;
				default:
					break;
			}
		}
		public void Teclado_KeyUp(object sender, KeyEventArgs e) {
			if (DadosDoTeste.Estado == Estado.Parado)
				switch (e.KeyCode) {
				case Keys.Up:
				case Keys.NumPad8:
				case Keys.Down:
				case Keys.NumPad2:
					//Para motor
					break;
				default:
					break;
			}
		}

		private void AtualizaSensores(object sender, SerialMessageArgument e) {
			switch (e.Objeto) {
				case "LS":
					SensorLS.Estado = e.boolValue;
					break;
				case "LI":
					SensorLI.Estado = e.boolValue;
					break;
				case "L":
					CelulaDeCarga.ValorLoad = e.intValue;
					break;
				case "E":
					// Motor.setEncoderValue(e.intValue);
					break;
				default:
					break;
			}
		}
	}
}