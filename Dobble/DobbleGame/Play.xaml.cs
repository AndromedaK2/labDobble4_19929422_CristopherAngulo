﻿using Model.game;
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

        /// <summary>
        /// Represent a game
        /// </summary>
        public DobbleGame DobbleGame { get; set; }

        /// <summary>
        /// Represent status of game 
        /// </summary>
        public TextBlock GameStatusText { get; set; }


        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="dobbleGame"></param>
        /// <param name="gameStatusText"></param>
        public Play(DobbleGame dobbleGame, TextBlock gameStatusText)
        {
            InitializeComponent();
            GameStatusText = gameStatusText;
            DobbleGame = dobbleGame;
            DobbleGame.StartGame();
            TxtGameStatus.Text = DobbleGame.ToString();
            TxtCurrentTurn.Text = DobbleGame.WhoseIsTurn().ToString();
            CardsZoneToString();
        }

        /// <summary>
        /// Get symbol or elemento from user interface and validate if spotit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Spotit(object sender, RoutedEventArgs e)
        {
            try
            {
                string element = TxtSpotit.Text;
                if (DobbleGame.Spotit(element)) {
                    MessageBox.Show("Acertaste "+ element + " es el símbolo en común");
                }
                else
                {
                    MessageBox.Show("Ups!! "+ element + " no es el símbolo en común");
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

        /// <summary>
        /// Pass next turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassTurn(object sender, RoutedEventArgs e)
        {
            try
            {
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

        /// <summary>
        /// Finish or end game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishGame(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Cards in the zone game to string
        /// </summary>
        private void CardsZoneToString()  
        {
            var cardsZone = DobbleGame.CardsZone;
            
            TxtFirstCard.Text  = cardsZone[0].ToString();
            TxtSecondCard.Text = cardsZone[1].ToString();      

        }

    }
}
