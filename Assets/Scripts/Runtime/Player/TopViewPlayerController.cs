using StudyProject.BuildingLogic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StudyProject.PlayerScripts
{
	public class TopViewPlayerController : MonoBehaviour, IPlayerController
	{
		[SerializeField]
		private Camera _playerCamera;
		
		[SerializeField]
		private LayerMask _selectionLayerMask;

		[SerializeField]
		private float _raycastDistance = 100f;
		
		[Header("Input Action References")]
		[SerializeField]
		private InputActionReference _performSelectionInputActionReference;

		private bool _isSelectionActive;
		private IInteractable _hoveredInteractable;
		
		private void OnEnable()
		{
			SubscribeEvents();
		}

		private void OnDisable()
		{
			UnsubscribeEvents();
		}

		private void Update()
		{
			if (!_isSelectionActive)
			{
				return;
			}
			
			Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _selectionLayerMask))
			{
				if (hit.collider.TryGetComponent(out IInteractable interactable))
				{
					if (_hoveredInteractable == null)
					{
						_hoveredInteractable = interactable;
						_hoveredInteractable.Hover();
					}
					else
					{
						if (_hoveredInteractable != interactable)
						{
							_hoveredInteractable.UnHover();
							_hoveredInteractable = interactable;
							_hoveredInteractable.Hover();
						}
					}
				}
				else if (_hoveredInteractable != null)
				{
					_hoveredInteractable.UnHover();
					_hoveredInteractable = null;
				}
			}
			else if (_hoveredInteractable != null)
			{
				_hoveredInteractable.UnHover();
				_hoveredInteractable = null;
			}
		}

		public void ActivateSelection()
		{
			_isSelectionActive = true;
			SubscribeEvents();
		}

		public void DeactivateSelection()
		{
			_isSelectionActive = false;
			UnsubscribeEvents();
			
			if (_hoveredInteractable != null)
			{
				_hoveredInteractable.UnHover();
				_hoveredInteractable = null;
			}
		}

		private void SubscribeEvents()
		{
			_performSelectionInputActionReference.action.performed += OnSelectionPerformedEventHandler;
			_performSelectionInputActionReference.action.Enable();
		}

		private void UnsubscribeEvents()
		{
			_performSelectionInputActionReference.action.performed -= OnSelectionPerformedEventHandler;
			_performSelectionInputActionReference.action.Disable();
		}

		private void OnSelectionPerformedEventHandler(InputAction.CallbackContext callback)
		{
			Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _selectionLayerMask))
			{
				if (hit.collider.TryGetComponent(out IInteractable interactable))
				{
					interactable.Select();
				}
			}
		}
		
		private void OnDrawGizmos()
		{
			if (_playerCamera == null)
			{
				return;
			}

			Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

			Gizmos.color = Color.green;
			Gizmos.DrawRay(ray.origin, ray.direction * _raycastDistance);

			if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _selectionLayerMask))
			{
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(hit.point, 0.15f);
			}
		}
	}
}