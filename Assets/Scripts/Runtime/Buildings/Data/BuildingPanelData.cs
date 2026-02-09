using System;
using UnityEngine;

namespace StudyProject.BuildingLogic
{
	[Serializable]
	public class BuildingPanelData
	{
		public string Name = "";
		public int Level;
		public int WorkersSet;
		public int AvailableWorkers;
		public int NextLevel;
		public int NextLevelAvailableWorkers;
		public Sprite WorkerIcon;

		public int BasicProduction;
		public int WorkersProduction;
		public int GeneralProduction;
	}
}