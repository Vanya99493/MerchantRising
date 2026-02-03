using DG.Tweening;
using UnityEngine;

namespace StudyProject.CardLogic
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;
		
		[SerializeField]
		private Transform _firstTransform;

		[SerializeField]
		private Transform _secondTransform;

		[Space(10)]
		[SerializeField]
		private float _movementTime = 1f;

		private bool _isMoved;

		private void Awake()
		{
			_camera.transform.position = _firstTransform.position;
			_camera.transform.eulerAngles = _firstTransform.eulerAngles;
		}

		public void StartMovement()
		{
			if (_isMoved)
			{
				return;
			}
			
			_isMoved = true;
			
			Sequence cameraMovementSequence = DOTween.Sequence();
			cameraMovementSequence.Append(_camera.transform.DOMove(_secondTransform.position, _movementTime).SetEase(Ease.Linear));
			cameraMovementSequence.Append(_camera.transform.DORotate(_secondTransform.eulerAngles, _movementTime).SetEase(Ease.Linear));
		}
	}
}