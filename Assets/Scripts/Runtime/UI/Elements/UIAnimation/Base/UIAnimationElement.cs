using System;
using UnityEngine;

namespace StudyProject.UI
{
	public abstract class UIAnimationElement : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		protected float _animationDuration = 1f;
		
		public abstract void StartAnimation(Action onCompleteCallback = null);
		public abstract void InterruptAnimation();
	}
}