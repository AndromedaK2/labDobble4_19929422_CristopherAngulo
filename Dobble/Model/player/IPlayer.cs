using Model.card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.player
{
    public interface IPlayer
    {
        void AddCards(List<Card> cards);
        void RemoveCards();

    }
}
