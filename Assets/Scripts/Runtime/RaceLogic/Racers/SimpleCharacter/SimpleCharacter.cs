using UnityEngine;

namespace StudyProject.RaceLogic
{
	public class SimpleCharacter : RacerBase
	{
		private const float MIN_SPEED = 2f;
		private const float MAX_SPEED = 5f;
		
		[SerializeField]
		private SimpleCharacterAnimatorController _simpleCharacterAnimatorController;

		[SerializeField]
		private SimpleCharacterColorController _simpleCharacterColorController;

		private float _currentSpeed;
		private bool _isRunning;
		private bool _isFinished;

		public override void Initialize(RacerData racerData)
		{
			base.Initialize(racerData);

			_simpleCharacterAnimatorController.Initialize();
			_simpleCharacterColorController.Initialize(RacerData.ColorType);
			_currentSpeed = 0f;
			_isRunning = false;
			_isFinished = false;
		}

		private void Update()
		{
			if (!_isRunning)
			{
				return;
			}

			Move();
		}

		public override void SetSpeed(float speed)
		{
			_currentSpeed = speed;
			_simpleCharacterAnimatorController.SetSpeed(_currentSpeed);
		}

		public override void StartOrProceedRun()
		{
			if (_isFinished)
			{
				return;
			}

			_isRunning = true;
			float speedVariability = MAX_SPEED - MIN_SPEED;
			
			float speedPowerRelated = speedVariability * 0.6f;
			float racerPower = RacerData.Strength * RacerData.Agility / 100f;
			float adjustedPowerRelatedSpeed = speedPowerRelated * racerPower;
			
			float speedRandomRelated = speedVariability * 0.4f;
			float randomCoefficient = Random.Range(0.5f, 1f);
			float adjustedRandomRelatedSpeed = speedRandomRelated * randomCoefficient;

			float newSpeed = MIN_SPEED + adjustedPowerRelatedSpeed + adjustedRandomRelatedSpeed;
			
			//Debug.Log($"Racer {RacerData.Name} speed = {newSpeed} \n\tPower related speed: {adjustedPowerRelatedSpeed}\n\tRandom related speed: {adjustedRandomRelatedSpeed}");
			
			SetSpeed(newSpeed);
		}

		public override void FinishRun()
		{
			base.FinishRun();

			_isRunning = false;
			_isFinished = true;
			SetSpeed(0f);
		}

		private void Move()
		{
			transform.position += transform.forward * (_currentSpeed * Time.deltaTime);
		}
	}
}