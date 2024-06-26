﻿using Model.card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.player
{
	/// <summary>
	/// @author Cristopher Angulo
	/// @implNote This class represent a dobble game player. Implement IPlayer </summary>
	/// <seealso cref="IPlayer"/>

	public class Player : IPlayer
	{
		private readonly bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			Points = Cards.Count;
		}


		#region properties
		/// <summary>
		/// @description Username of player in string format
		/// </summary>
		public string Username { get; set; }
		/// <summary>
		/// @description this list of cards owned by player
		/// </summary>
		public List<Card> Cards { get; set;  } 
        /// <summary>
        /// @description Is the sum  for each card
        /// </summary> 
        public int Points { get; set; }


		#endregion

		#region constructor

		/// <summary>
		/// @implNote  Main Constructor </summary>
		/// <param name="username"> name of player </param>
		public Player(string username)
		{


			Username = username;
			Cards = new List<Card>();
			if (!InstanceFieldsInitialized)
			{
				InitializeInstanceFields();
				InstanceFieldsInitialized = true;
			}
		}
		#endregion

		#region public methods

		/// <summary>
		/// @implNote this method receive a card list to added his card list attribute </summary>
		/// <param name="cards"> list of cards </param>
		/// <seealso cref="Card"/>
		public  void AddCards(List<Card> cards)
		{
            Cards.AddRange(cards);
			Points = Cards.Count;
		}

		public void RemoveCards() 
		{
			Cards = new List<Card>();
			Points = 0;
		}

		/// <summary>
		/// @implNote  this method is overriding to return a player string </summary>
		/// <returns> player in a string format </returns>
		public override string ToString()
		{
			string cardsString = ""; 
			if (Cards.Count > 0)
			{
                for (int i = 0; i < Cards.Count; i++)
                {
					cardsString +=  Cards[i];

				}
            }
            else
            {
				cardsString += "No tiene cartas";
            }
			return "\n\n Jugador: \n" + " Nombre de usuario: " + Username.ToString() + "\n" + "Cartas: \n "+cardsString + "\n" + " Puntos: " + Cards.Count.ToString();
		}


		/// <summary>
		/// @implNote verify if 2 objects are equals accord properties and others validations </summary>
		/// <param name="o"> any object </param>
		/// <returns> true if objects are equals or false if objects are not equals </returns>

		public override bool Equals(object obj)
		{
			return obj is Player player &&
				   Username == player.Username;
		}

        public override int GetHashCode()
        {
			return 0;
        }
        #endregion

    }

}
