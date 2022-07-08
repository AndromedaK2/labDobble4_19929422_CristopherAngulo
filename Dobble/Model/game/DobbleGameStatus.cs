using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.game
{
	public sealed class DobbleGameStatus
	{
		public static readonly DobbleGameStatus CREATED = new DobbleGameStatus("CREATED", InnerEnum.CREATED, "Juego Creado");
		public static readonly DobbleGameStatus STARTED = new DobbleGameStatus("STARTED", InnerEnum.STARTED, "Juego Inicializado");
		public static readonly DobbleGameStatus FINISHED = new DobbleGameStatus("FINISHED", InnerEnum.FINISHED, "Juego Finalizado");

		private static readonly List<DobbleGameStatus> valueList = new List<DobbleGameStatus>();

		static DobbleGameStatus()
		{
			valueList.Add(CREATED);
			valueList.Add(STARTED);
			valueList.Add(FINISHED);
		}

		public enum InnerEnum
		{
			CREATED,
			STARTED,
			FINISHED
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;
		private string statusName;

		internal DobbleGameStatus(string name, InnerEnum innerEnum, string statusName)
		{
			this.statusName = statusName;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public override string ToString()
		{
			return statusName;
		}
		 
		public static DobbleGameStatus[] Values()
		{
			return valueList.ToArray();
		}
		 
		public int Ordinal()
		{
			return ordinalValue;
		}

		public static DobbleGameStatus ValueOf(string name)
		{
			foreach (DobbleGameStatus enumInstance in DobbleGameStatus.valueList)
			{
				if (enumInstance.nameValue == name) 
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}
