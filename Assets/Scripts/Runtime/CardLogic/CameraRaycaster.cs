using UnityEngine;
using UnityEngine.InputSystem;

namespace StudyProject.CardLogic
{
	public class CameraRaycaster : MonoBehaviour
	{
		[SerializeField]
		private Camera _playerCamera;
		
		[SerializeField]
		private LayerMask _targetLayerMask;

		[SerializeField]
		private InputActionReference _raycastInputActionReference;
		
		private void OnEnable()
		{
			_raycastInputActionReference.action.performed += OnRaycastInputActionPreformed;
			_raycastInputActionReference.action.Enable();
		}

		private void OnDisable()
		{
			_raycastInputActionReference.action.performed -= OnRaycastInputActionPreformed;
			_raycastInputActionReference.action.Disable();
		}

		private void OnRaycastInputActionPreformed(InputAction.CallbackContext ctx)
		{
			Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100f, _targetLayerMask))
			{
				if (hit.collider.TryGetComponent(out CardBase cardBase))
				{
					cardBase.SwapCard();
				}
			}
		}
	}
}