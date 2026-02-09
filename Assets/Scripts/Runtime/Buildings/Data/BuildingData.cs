using System;
using System.Collections.Generic;
using StudyProject.BuildingLogic.Workers;

namespace StudyProject.BuildingLogic
{
	[Serializable]
	public class BuildingData
	{
		public string Name = "";
		public int Level;
		public BuildingType BuildingType;
		public List<WorkerData> WorkersData = new();
		public UpgradesData UpgradesData;
	}
}