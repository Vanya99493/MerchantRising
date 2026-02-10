using System;
using System.Collections.Generic;

namespace StudyProject.BuildingLogic
{
	[Serializable]
	public class BuildingData
	{
		public string Name = "";
		public BuildingType BuildingType;
		public int CurrentLevel;
		public int Storage;
		public List<WorkersOfTypeData> WorkersNumberData = new();
	}
}