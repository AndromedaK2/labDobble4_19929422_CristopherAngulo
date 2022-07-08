using Model.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.turn
{
	/// <summary>
	/// @author Cristopher Angulo
	/// @implNote This class represent a turn in the game
	/// It is possible to keep extend this class with </summary>
	/// <seealso cref="Player"/>
	public class Turn
	{

		//region attributes
		/// <summary>
		/// @description Player associated to the current turn
		/// </summary>
		public Player Player { get; set; } 
		//endregion



		//region constructor
		public Turn(Player player)
		{
			this.Player = player;
		}
		//endregion

		//region public methods

		/// <summary>
		/// @implNote  this method is overriding to return a turn string </summary>
		/// <returns> turn in a string format </returns>

		public override string ToString()
		{
			return "\nJugador: " + Player..ToUpper() + '\n';
		}
		//endregion


	}

}
