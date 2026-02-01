using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.ScriptableObjects.RacersData
{
	[CreateAssetMenu(fileName = "RacersCollectionDataAsset", menuName = "Scriptable Objects/Data Assets/Racers/Racers Collection Data Asset")]
	public class RacersCollectionDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public List<RacerDataAsset> Racers = new();
	}
}