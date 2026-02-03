using System;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.CardsPairMiniGameScripts
{
	public class CardsPairMiniGamePanel : BasePanel
	{
		public event Action<int> StartMiniGameEvent;

		[SerializeField]
		private Button _startMiniGameButton;
		
		[SerializeField]
		private SliderElement _sliderElement;

		protected override void SubscribeOnEvents()
		{
			base.SubscribeOnEvents();

			_startMiniGameButton.onClick.AddListener(OnStartMiniGameButtonClickEventHandler);
			
			_sliderElement.Initialize();
		}

		protected override void UnsubscribeFromEvents()
		{
			base.UnsubscribeFromEvents();
			
			_startMiniGameButton.onClick.RemoveListener(OnStartMiniGameButtonClickEventHandler);
		}

		private void OnStartMiniGameButtonClickEventHandler()
		{
			StartMiniGameEvent?.Invoke((int)_sliderElement.Value);
		}
	}
}