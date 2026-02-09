using StudyProject.BuildingLogic;
using UnityEngine;

namespace StudyProject.ScriptableObjects.BuildingsData
{
	[CreateAssetMenu(fileName = "BuildingsDataAsset", menuName = "Scriptable Objects/Data Assets/Buildings/Building Data Asset")]
	public class BuildingDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public BuildingData BuildingData;
	}
}