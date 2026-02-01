using System.Collections.Generic;
using System.Linq;
using StudyProject.Enums;
using UnityEngine;

namespace StudyProject.RaceLogic
{
	public class RaceCameraController : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private DirectionType _raceDirectionType;

		[Space(10)]
		[SerializeField]
		private Vector3 _startPosition;

		[SerializeField]
		private Vector3 _finishPosition;

		[SerializeField]
		private float _maximalGap;

		private List<Transform> _racers = new();
		
		public void SetRacers(List<Transform> racers)
		{
			ClearRacers();
			_racers = racers;
		}

		public void ClearRacers()
		{
			_racers.Clear();
		}

		private void LateUpdate()
		{
			if (_racers.Count <= 0)
			{
				_camera.transform.position = _startPosition;
				return;
			}
			
			CalculateCameraPosition();
		}

		private void CalculateCameraPosition()
		{
			List<float> positions = _racers.Select(x => _raceDirectionType == DirectionType.oX ? x.position.x : x.position.z).ToList();

			float maximal = positions[0];
			float sum = 0f;
			
			foreach (var position in positions)
			{
				sum += position;
				if (position > maximal)
				{
					maximal = position;
				}
			}

			float average = sum / positions.Count;
			
			float newCameraPosition = Mathf.Abs(average - maximal) >= _maximalGap
				? maximal - _maximalGap
				: average;

			float xPosition =  _raceDirectionType == DirectionType.oX 
				? Mathf.Clamp(newCameraPosition, _startPosition.x, _finishPosition.x) 
				: _camera.transform.position.x;
			
			float zPosition = _raceDirectionType == DirectionType.oZ 
				? Mathf.Clamp(newCameraPosition, _startPosition.z, _finishPosition.z) 
				: _camera.transform.position.z;
			
			_camera.transform.position = new Vector3(xPosition, _camera.transform.position.y, zPosition);
		}
	}
}