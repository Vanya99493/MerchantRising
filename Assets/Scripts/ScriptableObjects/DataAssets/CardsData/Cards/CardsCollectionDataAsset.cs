using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.ScriptableObjects.CardsData
{
	[CreateAssetMenu(fileName = "CardsCollectionDataAsset", menuName = "Scriptable Objects/Data Assets/Cards/Cards Collection Data Asset")]
	public class CardsCollectionDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public List<CardDataAsset> Cards = new();
	}
}