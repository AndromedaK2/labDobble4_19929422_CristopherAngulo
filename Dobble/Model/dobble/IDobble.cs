

using Model.card;
using System.Collections.Generic;

namespace Model.dobble
{
	/// <summary>
	/// @author Cristopher Angulo
	/// @description interface of a cards set o dobble
	/// </summary>

	public interface IDobble
	{

		bool IsDobble();

		string GetMissingCards();

		Card GetNthCard(List<Card> cards, int position);

		Card GetNthCard(int position);

		int GetRequiredElements(Card card);

		int GetTotalCards(Card card);

		int GetMaxNumberOfCards(int order);

		void RemoveCard(Card card);

		void AddCards(List<Card> cards); 

		void AddCard(Card card);

	}

}