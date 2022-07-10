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
        DobbleGame DobbleGame = null;
        public Register(DobbleGame dobbleGame)
        {
            InitializeComponent();
            this.DobbleGame = dobbleGame;

        }

        private void RegisterPlayer(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = TxtPlayerName.Text;
                this.DobbleGame.Register(username);
                MessageBox.Show("Se ha registrado un jugador");
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido registrar el jugador");
            }


        }
    }
}
