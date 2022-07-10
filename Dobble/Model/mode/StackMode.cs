using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.mode
{
	using Model.card;
    using Model.dobble;
    using Model.game;
	using Model.player;
	using System.Collections.Generic;

	/// <summary>
	/// @author Cristopher Angulo
	/// @description this class represent a concrete mode in game
	/// </summary>

	public class StackMode : IMode
	{


		#region public methods

		/// <summary>
		/// @implNote initialize and start game with a specific logic. In this case we get the first card
		/// and second card, then we add this cards in the zone cards and remove them of deck or cards set </summary>
		/// <param name="dobbleGame"> representation of a game </param>
		/// <returns>  dobble game </returns>
		public  DobbleGame StartGame(DobbleGame dobbleGame)
		{
			Dobble dobble = dobbleGame.Dobble;
			Card firstCard = dobble.GetNthCard(0);
			Card secondCard = dobble.GetNthCard(1);

			List<Card> cards = new();
			cards.Add(firstCard);
			cards.Add(secondCard);

			dobbleGame.CardsZone = cards;
			dobble.RemoveCard(firstCard);
			dobble.RemoveCard(secondCard);

			return dobbleGame;
		}

		/// <summary>
		/// @implNote identify the element in common between 2 cards </summary>
		/// <param name="element"> any object </param>
		/// <param name="cards"> list of cards </param>
		/// <returns> true if 2 cards have the element in common or false if it is the opposite </returns>
		public bool Spotit(object element, List<Card> cards)
		{
			Card firstCard = cards[0];
			Card secondCard = cards[1];
			return firstCard.Elements.Contains(element) && secondCard.Elements.Contains(element);
		}

		/// <summary>
		/// @implNote update players cards using method addcards of player object </summary>
		/// <param name="player"> represent a player in the game </param>
		/// <param name="cards"> represent list of cards </param>
		/// <returns> player with new cards </returns>
		public Player UpdatePlayerCards(Player player, List<Card> cards)
		{
			player.AddCards(cards);
			return player;
		}

		/// <summary>
		/// @implNote this method send zone cards to bottom of cards set </summary>
		/// <param name="dobbleCards"> represents list of cards </param>
		/// <param name="cards"> represent zone cards </param>
		/// <returns> list of cards </returns>

		public List<Card> ResetDobbleCard(List<Card> dobbleCards, List<Card> cards)
		{
            dobbleCards.AddRange(cards);
			return dobbleCards;
		}

		/// <summary>
		/// @implNote  this method clean cards zone </summary> 
		/// <param name="cards"> represent list of cards </param>
		/// <returns> clean cards zone </returns>
		public List<Card> ResetCardsZone(List<Card> cards)
		{
			cards.Clear();
			return cards;
		}

		/// <summary>
		/// @implNote reset dobble game
		/// </summary>

		public void EndGame(DobbleGame dobbleGame)
		{
			dobbleGame.Players.ForEach(player =>
			{
				player.RemoveCards();
			});
		}

		/// <summary>
		/// @implNote  this method get the winner of the game comparing the points associated </summary>
		/// <param name="players"> represent list of players </param>
		/// <returns> winner as a player </returns>

		public Player GetWinner(List<Player> players)
		{
			Player player = players.OrderByDescending(player=> player.Points).First();
			return player;
		}

        public List<Card> ResetDobbleCards(List<Card> dobbleCards, List<Card> cards)
        {
			dobbleCards.AddRange(cards);
			return dobbleCards;
        }


        #endregion
    }



}