using StudyProject.RaceLogic;
using UnityEngine;

namespace StudyProject.ScriptableObjects.RacersData
{
	[CreateAssetMenu(fileName = "CharacterDataAsset", menuName = "Scriptable Objects/Data Assets/Racers/Racer Data Asset")]
	public class RacerDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public RacerData RacerData;
	}
}