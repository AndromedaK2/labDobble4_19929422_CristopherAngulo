using Model.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para Play.xaml
    /// </summary>
    public partial class Play : Window
    {
        public DobbleGame DobbleGame { get; set; }

        public Play(DobbleGame dobbleGame)
        {
            InitializeComponent();
            DobbleGame = dobbleGame;
            TxtGameStatus.Text = DobbleGame.ToString();
            DobbleGame.StartGame();
            TxtCurrentTurn.Text = DobbleGame.WhoseIsTurn().ToString();
            CardsZoneToString();
        }

        private void Spotit(object sender, RoutedEventArgs e)
        {
            try
            {
                string element = TxtSpotit.Text;
                if (DobbleGame.Spotit(element)) {
                    MessageBox.Show("Acertaste");
                }
                else
                {
                    MessageBox.Show("Ups!! Ese no es el símbolo en cómun");
                }
                DobbleGame.StartGame();
                CardsZoneToString();
                TxtCurrentTurn.Text = DobbleGame.WhoseIsTurn().ToString();
               
            }
            catch (ArgumentOutOfRangeException)
            {
                TxtFirstCard.Text  = "No quedan más cartas";
                TxtSecondCard.Text = "No quedan más cartas";

                MessageBox.Show("No quedan suficientes cartas para jugar");
            }
            catch(Exception)
            {
                MessageBox.Show("Ha ocurrido un error intente nuevamente");
            }
            finally
            {
                TxtGameStatus.Text = DobbleGame.ToString();
            }
        }

        private void PassTurn(object sender, RoutedEventArgs e)
        {
            try
            {
                DobbleGame.PassTurn();
                TxtCurrentTurn.Text = DobbleGame.WhoseIsTurn().ToString();
                DobbleGame.StartGame();
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

        private void FinishGame(object sender, RoutedEventArgs e)
        {
            try
            {
                DobbleGame.EndGame();
                MessageBox.Show(DobbleGame.Winner());
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
            
            TxtFirstCard.Text  = cardsZone[0].ToString();
            TxtSecondCard.Text = cardsZone[1].ToString();      

        }

    }
}
