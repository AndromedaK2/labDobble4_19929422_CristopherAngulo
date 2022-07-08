

using Model.card;
using System.Collections.Generic;

namespace Model.Dobble
{
	/// <summary>
	/// @author Cristopher Angulo
	/// @description interface of a cards set o dobble
	/// </summary>

	public interface IDobble
	{

		void AddCards(List<Card> cards);

		void AddCard(Card card);

	}

}