using DG.Tweening;
using UnityEngine;

namespace StudyProject.CardLogic
{
	public class CardAnimationController : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _swapOffest;

		[SerializeField]
		private float _animationDuration;

		private Vector3 _initializePosition;
		private Sequence _animationSequence;
		
		public void Initialize(Vector3 initialPosition)
		{
			_initializePosition = initialPosition;
		}

		public void PlayAnimation(bool isForwardAnimation = true)
		{
			float halfDuration = _animationDuration / 2f;
			
			_animationSequence?.Kill();
			_animationSequence = DOTween.Sequence();
			_animationSequence.Append(transform.DOLocalMove(_initializePosition + _swapOffest, halfDuration).SetEase(Ease.Linear));
			_animationSequence.Append(transform.DOLocalRotate(new Vector3(0f, 0f, 90f), halfDuration).SetEase(Ease.InQuad));
			_animationSequence.OnComplete(() =>
			{
				_animationSequence.Append(transform.DOLocalMove(_initializePosition, halfDuration).SetEase(Ease.Linear));
				_animationSequence.Append(transform.DOLocalRotate(new Vector3(0f, 0f, isForwardAnimation ? 0f : 180f), halfDuration).SetEase(Ease.OutQuad));
			});
		}
	}
}