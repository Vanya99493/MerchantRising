using System.Collections.Generic;
using StudyProject.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StudyProject.DiceLogic
{
	public class Dice : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;
		
		[Header("Settings")]
		[SerializeField]
		private float _pullPower;

		[SerializeField]
		private float _rollPower;

		[SerializeField]
		private float _minHeight;
		
		[SerializeField]
		private float _maxHeight;
		
		[Space(10)]
		[SerializeField]
		private InputActionReference _rollInputActionReference;

		private bool _isRollingInputActionPerformed;
		private bool _isRolling;
		private bool _isRolled;
		private Vector3 _rollDirection;
		
		private readonly List<Pair<Vector3, DiceFace>> _faces = new()
		{
			new Pair<Vector3, DiceFace>(Vector3.up, DiceFace.Up),
			new Pair<Vector3, DiceFace>(Vector3.down, DiceFace.Down),
			new Pair<Vector3, DiceFace>(Vector3.right, DiceFace.Right),
			new Pair<Vector3, DiceFace>(Vector3.left, DiceFace.Left),
			new Pair<Vector3, DiceFace>(Vector3.forward, DiceFace.Forward),
			new Pair<Vector3, DiceFace>(Vector3.back, DiceFace.Back),
		};
		
		private void OnEnable()
		{
			_rollInputActionReference.action.performed += OnRollInputActionPerformed;
			_rollInputActionReference.action.canceled += OnRollInputActionCanceled;
			
			_rollInputActionReference.action.Enable();
		}

		private void OnDisable()
		{
			_rollInputActionReference.action.performed -= OnRollInputActionPerformed;
			_rollInputActionReference.action.canceled -= OnRollInputActionCanceled;
			
			_rollInputActionReference.action.Disable();
		}

		private void OnRollInputActionPerformed(InputAction.CallbackContext ctx)
		{
			GenerateRollDirection();

			_isRolling = true;
			_isRollingInputActionPerformed = true;
		}

		private void OnRollInputActionCanceled(InputAction.CallbackContext ctx)
		{
			_isRollingInputActionPerformed = false;
		}
		
		private void Update()
		{
			if (_isRolling)
			{
				if ((transform.position.y > _minHeight && !_isRollingInputActionPerformed) || transform.position.y > _maxHeight)
				{
					_isRolling = false;
					_isRolled = true;
				}
				
				Pull();
				Roll();
			}

			if (_isRolled && _rigidbody.IsSleeping())
			{
				Debug.Log((int)GetTopFace());
				_isRolled = false;
			}
		}

		private void GenerateRollDirection()
		{
			_rollDirection = new Vector3(
				Random.Range(-179f, 179f),
				Random.Range(-179f, 179f),
				Random.Range(-179f, 179f)
				);
		}

		private void Pull()
		{
			_rigidbody.AddForce(Vector3.up * (_pullPower * Time.deltaTime), ForceMode.Acceleration);
		}

		private void Roll()
		{
			_rigidbody.AddTorque(_rollDirection * (_rollPower * Time.deltaTime), ForceMode.Acceleration);
		}

		private DiceFace GetTopFace()
		{
			float bestDot = -1f;
			DiceFace result = DiceFace.Up;

			foreach (var facePair in _faces)
			{
				float dot = Vector3.Dot(transform.TransformDirection(facePair.FirstValue), Vector3.up);
				if (dot > bestDot)
				{
					bestDot = dot;
					result = facePair.SecondValue;
				}
			}

			return result;
		}
	}
}