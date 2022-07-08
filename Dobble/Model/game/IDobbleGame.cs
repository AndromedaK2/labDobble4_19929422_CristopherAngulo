using Model.card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.game
{
	/// <summary>
	/// @author Cristopher Angulo
	/// @description interface of dobble game
	/// </summary>
	public interface IDobbleGame
	{
		string Register(string username);
		void StartGame(); 
		bool Spotit(object element);
		void PassTurn(); 
		void NextTurn();
		void ResetDobbleCards();
		void ResetCardsZone();
		string Winner();
		void EndGame();

	}

}
