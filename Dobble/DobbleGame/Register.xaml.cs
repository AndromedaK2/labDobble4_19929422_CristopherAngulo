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
using Model.player;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        /// <summary>
        /// Represent a game
        /// </summary>
        readonly DobbleGame DobbleGame = null;
        /// <summary>
        /// Represent status of game 
        /// </summary>
        public TextBlock GameStatusText { get; set; }

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="dobbleGame"></param>
        /// <param name="GameStatusText"></param>
        public Register(DobbleGame dobbleGame, TextBlock GameStatusText)
        {
            InitializeComponent();
            this.DobbleGame = dobbleGame;
            this.GameStatusText = GameStatusText;

        }

        /// <summary>
        /// Register a player in the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterPlayer(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = TxtPlayerName.Text;
             
                MessageBox.Show(this.DobbleGame.Register(username));
                GameStatusText.Text = this.DobbleGame.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido registrar el jugador");
            }


        }
    }
}
