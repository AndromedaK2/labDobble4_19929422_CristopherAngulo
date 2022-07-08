using Model.card;
using Model.player;
using Model.game;
using System.Collections.Generic;

namespace Model.mode
{

    /// <summary>
    /// @author Cristopher Angulo
    /// @description interface that represent contract for all game modes in dobbleGame
    /// </summary>

    public interface IMode 
	{
		DobbleGame StartGame(DobbleGame dobbleGame);
		bool Spotit(object element, List<Card> cards);
		Player UpdatePlayerCards(Player player, List<Card> cards);
		List<Card> ResetDobbleCards(List<Card> dobbleCards, List<Card> cards);
		List<Card> ResetCardsZone(List<Card> cards);
		void EndGame(DobbleGame dobbleGame);
		Player GetWinner(List<Player> players) ;


	}

}
