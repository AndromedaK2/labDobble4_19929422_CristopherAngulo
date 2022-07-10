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
        readonly DobbleGame DobbleGame = null;
        public TextBlock TextBlock { get; set; }
        public Register(DobbleGame dobbleGame, TextBlock textBlock)
        {
            InitializeComponent();
            this.DobbleGame = dobbleGame;
            this.TextBlock = textBlock;

        }

        private void RegisterPlayer(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = TxtPlayerName.Text;
             
                MessageBox.Show(this.DobbleGame.Register(username));
                TextBlock.Text = this.DobbleGame.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido registrar el jugador");
            }


        }
    }
}
