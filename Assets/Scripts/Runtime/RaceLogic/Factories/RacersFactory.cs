using UnityEngine;

namespace StudyProject.RaceLogic
{
	public class RacersFactory : MonoBehaviour
	{
		[SerializeField]
		private RacerBase _racerBasePrefab;

		public RacerBase InstantiateNewRacer(Vector3 position, Quaternion rotation, RacerData racerData)
		{
			var racer = Instantiate(_racerBasePrefab, position, rotation);
			racer.Initialize(racerData);
			racer.DestroyEvent += DestroyRacer;
			return racer;
		}

		private void DestroyRacer(RacerBase racer)
		{
			Destroy(racer.gameObject);
		}
	}
}