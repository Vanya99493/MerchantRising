using System;
using StudyProject.Enums;

namespace StudyProject.RaceLogic
{
	[Serializable]
	public struct RacerData
	{
		public int Id;
		public string Name;
		public ColorType ColorType;
		public int Strength;
		public int Agility;
		public int Endurance;
	}
}