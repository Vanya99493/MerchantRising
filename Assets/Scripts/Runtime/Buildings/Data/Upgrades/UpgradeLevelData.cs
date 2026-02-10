using System;
using System.Collections.Generic;

namespace StudyProject.BuildingLogic
{
	[Serializable]
	public class UpgradeLevelData
	{
		public int Level;
		public int UpgradeToNextLevelCost;
		public int BasicProduction;
		public List<WorkersOfTypeData> AvailableWorkers = new();
	}
}