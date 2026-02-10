using System;
using System.Collections.Generic;

namespace StudyProject.BuildingLogic
{
	[Serializable]
	public class BuildingPanelData
	{
		public string Name = "";
		public int Level;
		public int NextLevel;
		public int UpgradeToNextLevelCost;
		public List<BuildingPanelWorkersOfTypeData> WorkersTypeData = new();

		public int BasicProduction;
		public int WorkersProduction;
		public int GeneralProduction;
	}
}