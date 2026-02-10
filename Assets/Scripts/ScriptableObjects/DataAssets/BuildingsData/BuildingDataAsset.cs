using System.Collections.Generic;
using StudyProject.BuildingLogic;
using StudyProject.BuildingLogic.Workers;
using UnityEngine;

namespace StudyProject.ScriptableObjects.BuildingsData
{
	[CreateAssetMenu(fileName = "BuildingsDataAsset", menuName = "Scriptable Objects/Data Assets/Buildings/Building Data Asset")]
	public class BuildingDataAsset : ScriptableObject
	{
		public string Name = "";
		public BuildingType BuildingType;
		public List<WorkerData> WorkersData = new();
		public UpgradesData UpgradesData;
	}
}