﻿using Model.card;
using Model.dobble;
using Model.mode;
using Model.player;
using Model.turn;
using System.Collections.Generic;
using System.Linq;

namespace Model.game
{ 
	public class DobbleGame : IDobbleGame
	{


		#region Getter and Setters

		/// <summary>
		/// @description represent unique value to identify. Id is generated by a random function </summary>
		/// <seealso cref="Helper"/>
		public int Id { get; set; }

		/// <summary>
		/// @description game status is represented by an enum (CREATED, STARTED, FINISHED) </summary>
		/// <seealso cref="DobbleGameStatus"/>
		public DobbleGameStatus GameStatus { get; set; } = DobbleGameStatus.CREATED;

		/// <summary>
		/// @implNote get Name of game </summary>
		/// <returns> Name of game </returns>
		public string Name { get; set; }

		/// <summary>
		/// @implNote get Name of game </summary>
		/// <returns> Name of game </returns>
		public Dobble Dobble { get; set; }

		/// <summary>
		/// @implNote  get game Players </summary>
		/// <returns> Players </returns>

		public List<Player> Players { get; set; }



		/// <summary>
		/// @implNote  get status </summary>
		/// <returns> Dobble game status (FINISHED,STARTED,CREATED) </returns>

		public DobbleGameStatus Status { get; set; }


		/// <summary>
		/// @implNote  get all Turns in the game </summary>
		/// <returns> Turns </returns>

		public List<Turn> Turns { get; set; } = new List<Turn>();


		/// <summary>
		/// @implNote  get Players number </summary>
		/// <returns> Players number
		///  </returns>

		public int PlayersNumber { get; set; }


		/// <summary>
		/// @implNote  get Dobble game Mode </summary>
		/// <returns> Dobble game Mode </returns>
		public DobbleGameMode DobbleGameMode { get; set; }


		/// <summary>
		/// @implNote  get cards zone </summary>
		/// <returns> cards </returns>
		public List<Card> CardsZone { get; set; }

		/// <summary>
		/// @implNote  get game Mode </summary>
		/// <returns> Mode </returns>

		public IMode Mode { get; set; }

		#endregion

		#region constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public DobbleGame() { }

		/// <param Name="elements"> </param>
		/// <param Name="elementsPerCard"> </param>
		/// <param Name="maximumTotalCards"> </param>
		/// <param Name="DobbleGameMode"> </param>
		/// <param Name="PlayersNumber"> </param>
		/// <param Name="Name"> </param>
		/// <param Name="Players"> </param>
		/// <param Name="Turns"> </param>

		public DobbleGame(List<object> elements, int elementsPerCard, int maximumTotalCards, DobbleGameMode DobbleGameMode, int PlayersNumber, string Name, List<Player> Players, List<Turn> Turns)
		{
			Id = Helper.GenerateRandomNumber(1, 1000);
			this.PlayersNumber = PlayersNumber;
			Dobble = new Dobble(elements, elementsPerCard, maximumTotalCards);
			this.DobbleGameMode = DobbleGameMode;
			this.Name = Name;
			this.Players = Players;
			this.Turns = Turns;
			SetMode(DobbleGameMode);
		}

		/// <param Name="elements"> </param>
		/// <param Name="elementsPerCard"> </param>
		/// <param Name="maximumTotalCards"> </param>
		/// <param Name="DobbleGameMode"> </param>
		/// <param Name="PlayersNumber"> </param>
		/// <param Name="Name"> </param>
		public DobbleGame(List<object> elements, int elementsPerCard, int maximumTotalCards, DobbleGameMode DobbleGameMode, int PlayersNumber, string Name)
		{
			Id = Helper.GenerateRandomNumber(1, 1000);
			this.PlayersNumber = PlayersNumber;
			Dobble = new Dobble(elements, elementsPerCard, maximumTotalCards);
			this.DobbleGameMode = DobbleGameMode;
			this.Status = DobbleGameStatus.CREATED;
			this.Name = Name;
			this.Players = new List<Player>();
			this.CardsZone = new List<Card>();
			SetMode(DobbleGameMode);

		}
		#endregion

		#region public methods

		/// <summary>
		/// @implNote get first turn </summary>
		/// <returns> a turn </returns>
		public Turn WhoseIsTurn()
		{
			return Turns[0];

		}


		/// <summary>
		/// @implNote this method register player with his username in the game
		/// It also set up his turn. </summary>
		/// <param Name="username"> </param>
		/// <returns> true if method could register or false the opposite </returns>
		public string Register(string username)
		{
			Player player = new(username);
			if (Players.Contains(player))
			{
				return "Jugador ya existe";
			}
			if (PlayersNumber <= Players.Count)
			{
				return "No se ha logrado registrar, Capacidad maxima de jugadores";
			}
			Players.Add(player);
			Turn turn = new(player);
			Turns.Add(turn);
			return "Jugador registrado";

		}


		/// <summary>
		/// @implNote  set Mode
		/// </summary>
		public void SetMode(DobbleGameMode DobbleGameMode)
		{

			switch (DobbleGameMode)
			{
				case DobbleGameMode.STACKMODE:
					Mode = new StackMode();
					break;
			}

		}


		public void StartGame()
		{
			GameStatus = DobbleGameStatus.STARTED;
			Mode.StartGame(this);
		}

		/// <summary>
		/// @implNote this method use Mode to call spotit.It also
		/// updates player card, reset cards zone, reset Dobble cards and continue with next turn </summary>
		/// <seealso cref="IMode"/>
		/// <returns> true if player fin common element between cards or false if it is the opposite </returns>
		public bool Spotit(object element)
		{
			bool spotit = Mode.Spotit(element, CardsZone);
			if (spotit)
			{
				Player player = WhoseIsTurn().Player;
				int playerIndex = Players.IndexOf(player);
				player = Mode.UpdatePlayerCards(player, CardsZone);
				Players[playerIndex] = player;
				ResetCardsZone();
				NextTurn();
				return true;

			}
			ResetDobbleCards();
			ResetCardsZone();
			NextTurn();
			return false;

		}

		/// <summary>
		/// @implNote this method execute pass turn when player skip his turn.
		/// it also updates Turns and reset cards
		/// </summary>
		public void PassTurn()
		{
			ResetDobbleCards();
			ResetCardsZone();
			Turn currentTurn = WhoseIsTurn();
			int turnIndex = Turns.IndexOf(currentTurn);
			Turns.RemoveAt(turnIndex);
			Turns.Add(currentTurn);
		}

		/// <summary>
		/// @implNote  this method continue with next turn
		/// </summary>
		public void NextTurn()
		{
			Turn currentTurn = WhoseIsTurn();
			int turnIndex = Turns.IndexOf(currentTurn);
			Turns.RemoveAt(turnIndex);
			Turns.Add(currentTurn);
		}

		/// <summary>
		/// @implNote this method reset Dobble cards using Mode
		/// </summary>
		public void ResetDobbleCards()
		{
			Dobble.DobbleCards = Mode.ResetDobbleCards(Dobble.DobbleCards, CardsZone);
		}

		/// <summary>
		/// @implNote  this method reset cards zone using Mode
		/// </summary>
		public void ResetCardsZone()
		{
			CardsZone = Mode.ResetCardsZone(CardsZone);
		}

		/// <summary>
		/// @implNote  this methods get player who win the match </summary>
		/// <returns> player string format </returns>

		public string Winner()
		{

			Player player = Mode.GetWinner(Players);
			if (player.Points > 0)
			{
				return "Ganador: " + player.Username + "\n" + "Puntos: " + player.Points;
			}
			else
			{
				return "No hay ganador";
			}

		}

		/// <summary>
		/// @implNote  this method finish the game
		/// </summary>
		public void EndGame()
		{
			Mode.EndGame(this);
		}

		/// <summary>
		/// @implNote  this method is overriding to return a Dobble game string </summary>
		/// <returns> Dobble game in a string format </returns>
		public override string ToString()
		{
			string playersString = "";
			if (Players.Count>0) {

                for (int i = 0; i < Players.Count; i++)
                {
					playersString += Players[i];
				}
				
            }
            else
            {
				playersString = "No hay jugadores registrados";
            }

			string cardsString = "";
			if (CardsZone.Count > 0)
			{
				for (int i = 0; i < CardsZone.Count; i++)
				{
					cardsString += CardsZone[i];
				}
			}
			else
			{
				cardsString += "No hay cartas en juego";
			}

			return "Informacion del Juego Dobble:\n\n" + "- Id: " + Id.ToString() + "\n" + "- Nombre Juego: " + Name.ToString() + "\n" + "- Estado: " + GameStatus.ToString() + "\n" + "- Jugadores: " + playersString  + "\n\n" + "- Numero de jugadores: " + PlayersNumber.ToString() + "\n" + "- Zona de juego:\n " + cardsString + "\n" + "- " + Dobble.ToString() + "\n" +
				Dobble.GetMissingCards();

		}

		public override bool Equals(object obj)
		{
			return obj is DobbleGame game &&
				   Id == game.Id &&
				   EqualityComparer<DobbleGameStatus>.Default.Equals(GameStatus, game.GameStatus) &&
				   Name == game.Name &&
				   EqualityComparer<Dobble>.Default.Equals(Dobble, game.Dobble) &&
				   EqualityComparer<List<Player>>.Default.Equals(Players, game.Players) &&
				   EqualityComparer<DobbleGameStatus>.Default.Equals(Status, game.Status) &&
				   EqualityComparer<List<Turn>>.Default.Equals(Turns, game.Turns) &&
				   PlayersNumber == game.PlayersNumber &&
				   DobbleGameMode == game.DobbleGameMode &&
				   EqualityComparer<List<Card>>.Default.Equals(CardsZone, game.CardsZone) &&
				   EqualityComparer<IMode>.Default.Equals(Mode, game.Mode);
		}

		public override int GetHashCode()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// @implNote verify if 2 objects are equals accord properties and others validations </summary>
		/// <param Name="o"> any object </param>
		/// <returns> true if objects are equals or false if objects are not equals </returns>


		#endregion

	}


}