using UnityEngine;

namespace StudyProject.ScriptableObjects.RaceData
{
	[CreateAssetMenu(fileName = "RacerDataAsset", menuName = "Scriptable Objects/Data Assets/Race Data Asset")]
	public class RaceDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public float UpdateSpeedDelay { get; private set; }
	}
}