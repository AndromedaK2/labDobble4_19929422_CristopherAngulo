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

                MessageBox.Show(DobbleGame.ToString());


            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }

        }


        private List<object> MapElements()
        {
            List<object> mapElements = new();
            string[] elements = TxtElements.Text.Split(",");

            for (int i = 0; i < elements.Length; i++)    
                mapElements.Add(elements[i]);
            
            return mapElements;
        }



    }
}
