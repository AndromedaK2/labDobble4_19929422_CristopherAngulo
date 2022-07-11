using Model.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para Simulator.xaml
    /// </summary>
    public partial class Simulator : Window
    {
        public DobbleGame DobbleGame { get; set; }

        public TextBlock GameStatusText { get; set; }

        private bool FinishCurrentGame { get; set; } = false;
         
        public Simulator(DobbleGame dobbleGame, TextBlock gameStatusText)
        {
            InitializeComponent();
            GameStatusText = gameStatusText;
            DobbleGame = dobbleGame;
            DobbleGame.StartGame();
            TxtGameStatus.Text = DobbleGame.ToString();
            TxtCurrentTurn.Text = DobbleGame.WhoseIsTurn().ToString();
            CardsZoneToString();
        }


        private void StartGame(object sender, RoutedEventArgs e)
        {
            SimulatorCpuVSCpu();
        }
        private void SimulatorCpuVSCpu()
        {
            try
            {
                while (!FinishCurrentGame)
                {
                    int option = Helper.GenerateRandomNumber(1, 2);
                    switch (option)
                    {
                        case 1:
                            Spotit();
  
                            break;
                        case 2:
                            PassTurn();
                            break;
                        default:
                            FinishCurrentGame = true;
                            FinishGame();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error intente nuevamente");
            }
        }

        private void Spotit()
        {
            try
            {
                List<object> elements = DobbleGame.CardsZone[0].Elements;
                var element = elements[Helper.GenerateRandomNumber(0, elements.Count - 1)];
                TxtPlayerRegister.Text = "El jugador " + DobbleGame.WhoseIsTurn().Player.Username + " escogio el elemento: " + element;
                Thread.Sleep(1000);
                if (DobbleGame.Spotit(element))
                {
                    Thread.Sleep(1000);
                    TxtPlayerRegister.Text = "El jugador " + DobbleGame.WhoseIsTurn().Player.Username + " acertó";
                    MessageBox.Show("Acertaste " + element + " es el símbolo en común");
                }
                else
                {
                    Thread.Sleep(1000);
                    TxtPlayerRegister.Text = "El jugador " + DobbleGame.WhoseIsTurn().Player.Username + " no acertó";
                    MessageBox.Show("Ups!! " + element + " no es el símbolo en común");
                }
                DobbleGame.StartGame();
                CardsZoneToString();
                TxtCurrentTurn.Text = DobbleGame.WhoseIsTurn().ToString();

            }
            catch (ArgumentOutOfRangeException)
            {
                TxtFirstCard.Text = "No quedan más cartas";
                TxtSecondCard.Text = "No quedan más cartas";

                MessageBox.Show("No quedan suficientes cartas para jugar");
                FinishCurrentGame = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error intente nuevamente");
            }
            finally
            {
                TxtGameStatus.Text = DobbleGame.ToString();
            }


        }

        private void PassTurn() 
        {
            try
            {  
                Thread.Sleep(1000);
                TxtPlayerRegister.Text = "El jugador " + DobbleGame.WhoseIsTurn().Player.Username + " pasó de turno";
                DobbleGame.PassTurn();
                DobbleGame.StartGame();
                TxtCurrentTurn.Text = DobbleGame.WhoseIsTurn().ToString();
                CardsZoneToString(); 
       
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error intente nuevamente");

            }
            finally
            {
                TxtGameStatus.Text = DobbleGame.ToString();
            }

        }

        private void FinishGame()
        {
            try
            {
                DobbleGame.EndGame();
                MessageBox.Show(DobbleGame.Winner());
                this.TxtGameStatus.Text = DobbleGame.ToString();
                this.GameStatusText.Text = DobbleGame.ToString();

                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error intente nuevamente");


            }
            finally
            {
                TxtGameStatus.Text = DobbleGame.ToString();
            }

        }

        private void CardsZoneToString()
        {
            var cardsZone = DobbleGame.CardsZone;
            TxtFirstCard.Text = cardsZone[0].ToString();
            TxtSecondCard.Text = cardsZone[1].ToString();

        }

        private void CloseGame(object sender, RoutedEventArgs e)
        {
            FinishGame();
        }
    }
}
