using System;
using DG.Tweening;
using StudyProject.Enums;
using UnityEngine;

namespace StudyProject.UI.UIAnimation
{
	public class MoveAnimationElement : UIAnimationElement
	{
		[SerializeField]
		private DirectionType _animationDirection;
		
		[SerializeField]
		private float _closedAnchorPosition;

		[SerializeField]
		private float _openedAnchorPosition;

		private Tween _animationsTween;
		
		public bool IsOpened { get; private set; }

		public void Initialize(bool isOpened)
		{
			IsOpened = isOpened;
			float targetPosition = IsOpened ? _openedAnchorPosition : _closedAnchorPosition;
			PlayAnimation(targetPosition, 0f);
		}

		public override void StartAnimation(Action onCompleteCallback = null)
		{
			float targetPosition = IsOpened ? _closedAnchorPosition : _openedAnchorPosition;
			PlayAnimation(targetPosition, _animationDuration, onCompleteCallback);
			IsOpened = !IsOpened;
		}

		public override void InterruptAnimation()
		{
			_animationsTween?.Kill();
			_animationsTween = null;
		}

		private void PlayAnimation(float targetPosition, float animationDuration, Action onCompleteCallback = null)
		{
			InterruptAnimation();
			
			if (_animationDirection == DirectionType.oX)
			{
				_animationsTween = ((RectTransform)transform).DOAnchorPosX(targetPosition, animationDuration).OnComplete(() => onCompleteCallback?.Invoke());
			}
			else if (_animationDirection == DirectionType.oY)
			{
				_animationsTween = ((RectTransform)transform).DOAnchorPosY(targetPosition, animationDuration).OnComplete(() => onCompleteCallback?.Invoke());
			}
		}
	}
}