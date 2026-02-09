using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.ScriptableObjects.BuildingsData
{
	[CreateAssetMenu(fileName = "BuildingsCollectionDataAsset", menuName = "Scriptable Objects/Data Assets/Buildings/Buildings Collection Data Asset")]
	public class BuildingsCollectionDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public List<BuildingDataAsset> BuildingDataAssets = new();
	}
}