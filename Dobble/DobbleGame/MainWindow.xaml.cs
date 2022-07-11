using Model.game;
using Model.mode;
using System;
using System.Collections.Generic;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DobbleGame DobbleGame { get; set; }

        public MainWindow() 
        {
            InitializeComponent();
        }

        private void CreateGame(object sender, RoutedEventArgs e)
        {
            try
            {
                List<object> elements = MapElements();
                int totalCards = Int32.Parse(TxtTotalCards.Text.Trim());
                int playersNumber = Int32.Parse(TxtTotalPlayers.Text.Trim());
                string gameName = TxtGameName.Text.Trim();
                int elementsPerCard = Int32.Parse(TxtElementsPerCard.Text.Trim());
                DobbleGameMode dobbleGameMode =  DobbleGameMode.STACKMODE;

                DobbleGame = new DobbleGame(elements,elementsPerCard,totalCards,dobbleGameMode,playersNumber,gameName);

                TxtGameStatus.Text = DobbleGame.ToString();
                MessageBox.Show("Juego Creado");

            }
            catch (FormatException)
            {
                MessageBox.Show("Alguno de los campos es inválido");
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }

        }

        private List<object> MapElements()
        {
            List<object> mapElements = new();
            try
            {
                string[] elements = TxtElements.Text.Split(",");

                for (int i = 0; i < elements.Length; i++)
                    mapElements.Add(elements[i]);

                return mapElements;
            }
            catch (Exception)
            {
                MessageBox.Show("Elementos no válidos");
            }

            return mapElements;

        }

        private void RegisterPlayer(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DobbleGame is null)
                {
                    MessageBox.Show("Debe crear un juego");
                }
                else {
                    Register register = new(this.DobbleGame, TxtGameStatus);
                    register.Show();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido registrar el jugador");
            }
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DobbleGame is null)
                {

                    MessageBox.Show("Debe crear un juego");
                }
                else if (DobbleGame.Players.Count <= 0) {
                
                    MessageBox.Show("Debe registrar jugadores");

                }

                else
                {
                    Play play = new(DobbleGame, TxtGameStatus);
                    play.Show();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error intente nuevamente");
            }
        }

        private void Simulater(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DobbleGame is null)
                {

                    MessageBox.Show("Debe crear un juego");
                }
                else if (DobbleGame.Players.Count <= 0)
                {

                    MessageBox.Show("Debe registrar jugadores");
                }

                else
                {
                    Simulator simulator = new(DobbleGame, TxtGameStatus);
                    simulator.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error intente nuevamente");

            }
        }
    }
}
