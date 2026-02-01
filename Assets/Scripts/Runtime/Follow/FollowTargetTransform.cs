using UnityEngine;

namespace StudyProject.Follow
{
	public class FollowTargetTransform : MonoBehaviour
	{
		[SerializeField]
		private Transform _pivot;

		[SerializeField]
		private Transform _followedObject;

		[Header("Position")]
		[SerializeField]
		private bool _updatePosition;

		[SerializeField]
		private bool _updateByOY = true;

		[Header("Rotation")]
		[SerializeField]
		private bool _updateRotation;

		[SerializeField]
		private bool _smoothRotation;

		[SerializeField]
		private float _rotationSpeed;

		private void Update()
		{
			UpdateTransform();
		}

		private void UpdateTransform()
		{
			if (_updatePosition)
			{
				DoPositionUpdate();
			}

			if (_updateRotation)
			{
				DoRotationUpdate();
			}
		}

		private void DoPositionUpdate()
		{
			_pivot.position = new Vector3(
				_followedObject.position.x,
				_updateByOY ? _followedObject.position.y : _pivot.position.y,
				_followedObject.position.z
			);
		}

		private void DoRotationUpdate()
		{
			Quaternion targetRotation;

			if (_smoothRotation)
			{
				float rotationStep = _rotationSpeed * Time.deltaTime;
				targetRotation = Quaternion.Slerp(_pivot.rotation, _followedObject.rotation, rotationStep);
			}
			else
			{
				targetRotation = _followedObject.rotation;
			}

			_pivot.rotation = targetRotation;
		}

		public void SetFollowObject(Transform followedObject)
		{
			_followedObject = followedObject;
		}
	}
}