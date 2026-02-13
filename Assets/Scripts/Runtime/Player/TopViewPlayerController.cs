using StudyProject.BuildingLogic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StudyProject.PlayerScripts
{
	public class TopViewPlayerController : MonoBehaviour, IPlayerController
	{
		[SerializeField]
		private Transform _cameraPivot;
		
		[SerializeField]
		private Camera _playerCamera;
		
		[Header("Raycast settings")]
		[SerializeField]
		private LayerMask _selectionLayerMask;

		[SerializeField]
		private float _raycastDistance = 100f;
		
		[Header("Movement settings")]
		[SerializeField]
		private float _speed = 1f;
		
		[SerializeField]
		private float _boostSpeedMultiplier = 2f;

		[Header("Rotation")]
		[SerializeField]
		private float _rotationSpeed = 3f;

		[SerializeField]
		private float _minPitch = -80f;
		
		[SerializeField]
		private float _maxPitch = 80f;

		[Header("Scroll")]
		[SerializeField]
		private float _scrollSpeed = 1f;
		
		[SerializeField]
		private float _minimalScroll = 5f;

		[SerializeField]
		private float _maximalScroll = 100f;
		
		[Header("Input Action References")]
		[SerializeField]
		private InputActionReference _performSelectionInputActionReference;

		[SerializeField]
		private InputActionReference _rotationInputActionReference;

		[SerializeField]
		private InputActionReference _freeLookInputActionReference;

		[SerializeField]
		private InputActionReference _scrollInputActionReference;
		
		[SerializeField]
		private InputActionReference _moveInputActionReference;

		[SerializeField]
		private InputActionReference _boostMovementInputActionReference;

		private bool _isSelectionActive;
		private IInteractable _hoveredInteractable;
		
		private bool _isFreeLookMode;
		private float _pitch;
		private float _yaw;

		private float _cameraDistance;
		
		private float _speedMultiplier = 1f;


		private void Start()
		{
			_pitch = _cameraPivot.rotation.eulerAngles.x;
			_yaw = _cameraPivot.rotation.eulerAngles.y;
		}

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
			
			if (_isFreeLookMode)
			{
				Rotate();
				UnHoverHoveredInteractableObject();
			}
			else
			{
				CastSelectionRay();
			}
			
			Move();
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
			UnHoverHoveredInteractableObject();
		}

		private void SubscribeEvents()
		{
			_performSelectionInputActionReference.action.performed += OnSelectionPerformedEventHandler;
			
			_rotationInputActionReference.action.performed += OnRotationPerformedEventHandler;
			_rotationInputActionReference.action.canceled += OnRotationCanceledEventHandler;

			_scrollInputActionReference.action.performed += OnScrollPerformedEventHandler;
			
			_boostMovementInputActionReference.action.performed += OnBoostMovementPerformedEventHandler;
			_boostMovementInputActionReference.action.canceled += OnBoostMovementCanceledEventHandler;
			
			_performSelectionInputActionReference.action.Enable();
			_rotationInputActionReference.action.Enable();
			_freeLookInputActionReference.action.Enable();
			_scrollInputActionReference.action.Enable();
			_boostMovementInputActionReference.action.Enable();
			
			_moveInputActionReference.action.Enable();
		}

		private void UnsubscribeEvents()
		{
			_performSelectionInputActionReference.action.performed -= OnSelectionPerformedEventHandler;
			
			_rotationInputActionReference.action.performed -= OnRotationPerformedEventHandler;
			_rotationInputActionReference.action.performed -= OnRotationCanceledEventHandler;

			_scrollInputActionReference.action.performed -= OnScrollPerformedEventHandler;
			
			_boostMovementInputActionReference.action.performed -= OnBoostMovementPerformedEventHandler;
			_boostMovementInputActionReference.action.canceled -= OnBoostMovementCanceledEventHandler;
			
			_performSelectionInputActionReference.action.Disable();
			_rotationInputActionReference.action.Disable();
			_freeLookInputActionReference.action.Disable();
			_scrollInputActionReference.action.Disable();
			_boostMovementInputActionReference.action.Disable();
			
			_moveInputActionReference.action.Disable();
		}

		private void Rotate()
		{
			Vector2 mouseDelta = _freeLookInputActionReference.action.ReadValue<Vector2>();

			_yaw += mouseDelta.x * _rotationSpeed;
			_pitch -= mouseDelta.y * _rotationSpeed;
			_pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);
			
			_cameraPivot.rotation = Quaternion.Euler(_pitch, _yaw, 0f);
		}

		private void Move()
		{
			Vector2 movementInput = _moveInputActionReference.action.ReadValue<Vector2>();

			Vector3 forward = _cameraPivot.forward;
			forward.y = 0f;
			forward.Normalize();

			Vector3 right = _cameraPivot.right;
			right.y = 0f;
			right.Normalize();

			Vector3 direction = (forward * movementInput.y + right * movementInput.x).normalized;
			
			_cameraPivot.position += Time.deltaTime * _speed * _speedMultiplier * direction;
		}

		private void CastSelectionRay()
		{
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
					UnHoverHoveredInteractableObject();
				}
			}
			else if (_hoveredInteractable != null)
			{
				UnHoverHoveredInteractableObject();
			}
		}

		private void UnHoverHoveredInteractableObject()
		{
			if (_hoveredInteractable != null)
			{
				_hoveredInteractable.UnHover();
				_hoveredInteractable = null;
			}
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
		
		private void OnRotationPerformedEventHandler(InputAction.CallbackContext callback)
		{
			_isFreeLookMode = true;
		}
		
		private void OnRotationCanceledEventHandler(InputAction.CallbackContext callback)
		{
			_isFreeLookMode = false;
		}

		private void OnScrollPerformedEventHandler(InputAction.CallbackContext callback)
		{
			Vector2 scroll = callback.ReadValue<Vector2>();
			
			_cameraDistance -= scroll.y * _scrollSpeed;
			_cameraDistance = Mathf.Clamp(_cameraDistance, _minimalScroll, _maximalScroll);

			_playerCamera.transform.localPosition = new Vector3(
				_playerCamera.transform.localPosition.x,
				_playerCamera.transform.localPosition.y,
				-_cameraDistance);
		}

		private void OnBoostMovementPerformedEventHandler(InputAction.CallbackContext callback)
		{
			_speedMultiplier = _boostSpeedMultiplier;
		}

		private void OnBoostMovementCanceledEventHandler(InputAction.CallbackContext callback)
		{
			_speedMultiplier = 1f;
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