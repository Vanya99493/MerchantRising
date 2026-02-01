using UnityEngine;

namespace StudyProject.RaceLogic
{
	public class SimpleCharacterAnimatorController : MonoBehaviour
	{
		private const string SPEED_ANIMATOR_NAME = "Speed";
		private const string JUMP_ANIMATOR_NAME = "Jump";
		private const string GROUNDED_ANIMATOR_NAME = "Grounded";
		private const string FREE_FALL_ANIMATOR_NAME = "FreeFall";
		private const string MOTION_SPEED_ANIMATOR_NAME = "MotionSpeed";
		
		[SerializeField]
		private Animator _animator;

		public void Initialize()
		{
			SetSpeed(0f);
			SetJump(false);
			SetGrounded(true);
			SetFreeFall(false);
			SetMotionSpeed(1f);
		}
		
		public void SetSpeed(float speed)
		{
			_animator.SetFloat(SPEED_ANIMATOR_NAME, speed);
		}

		public void SetJump(bool isJump)
		{
			_animator.SetBool(JUMP_ANIMATOR_NAME, isJump);
		}

		public void SetGrounded(bool isGrounded)
		{
			_animator.SetBool(GROUNDED_ANIMATOR_NAME, isGrounded);
		}

		public void SetFreeFall(bool isFreeFall)
		{
			_animator.SetBool(FREE_FALL_ANIMATOR_NAME, isFreeFall);
		}

		public void SetMotionSpeed(float motionSpeed)
		{
			_animator.SetFloat(MOTION_SPEED_ANIMATOR_NAME, motionSpeed);
		}
	}
}