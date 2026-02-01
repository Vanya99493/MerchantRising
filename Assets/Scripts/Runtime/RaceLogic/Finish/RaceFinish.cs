using UnityEngine;

namespace StudyProject.RaceLogic
{
	public class RaceFinish : MonoBehaviour
	{
		[SerializeField]
		private LayerMask _racersLayerMask;
		
		private void OnTriggerEnter(Collider other)
		{
			if (((1 << other.gameObject.layer) & _racersLayerMask.value) != 0)
			{
				if (other.TryGetComponent(out RacerBase racer))
				{
					racer.FinishRun();
				}
			}
		}
	}
}