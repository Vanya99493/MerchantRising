using System;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.RacingPanelScripts
{
	public class RacingPanel : BasePanel, IRacingPanel
	{
		public event Action<int> PrepareRaceEvent;
		public event Action StartRaceEvent;
		public event Action StopRaceEvent;

		[Header("Buttons")]
		[SerializeField]
		private Button _prepareRaceButton;

		[SerializeField]
		private Button _startRaceButton;

		[SerializeField]
		private Button _stopRaceButton;

		[Header("Slider")]
		[SerializeField]
		private SliderElement _sliderElement;

		protected override void SubscribeOnEvents()
		{
			base.SubscribeOnEvents();
			
			_sliderElement.Initialize();
			
			_prepareRaceButton.onClick.AddListener(OnPrepareRaceButtonClickEventHandler);
			_startRaceButton.onClick.AddListener(OnStartRaceButtonClickEventHandler);
			_stopRaceButton.onClick.AddListener(OnStopRaceButtonClickEventHandler);

			_prepareRaceButton.gameObject.SetActive(true);
			_startRaceButton.gameObject.SetActive(false);
			_stopRaceButton.gameObject.SetActive(false);
			_sliderElement.gameObject.SetActive(true);
		}

		protected override void UnsubscribeFromEvents()
		{
			base.UnsubscribeFromEvents();
			
			_prepareRaceButton.onClick.RemoveListener(OnPrepareRaceButtonClickEventHandler);
			_startRaceButton.onClick.RemoveListener(OnStartRaceButtonClickEventHandler);
			_stopRaceButton.onClick.RemoveListener(OnStopRaceButtonClickEventHandler);
		}

		private void OnPrepareRaceButtonClickEventHandler()
		{
			PrepareRaceEvent?.Invoke((int)_sliderElement.Value);
			
			_prepareRaceButton.gameObject.SetActive(true);
			_startRaceButton.gameObject.SetActive(true);
			_stopRaceButton.gameObject.SetActive(false);
			_sliderElement.gameObject.SetActive(true);
		}

		private void OnStartRaceButtonClickEventHandler()
		{
			StartRaceEvent?.Invoke();
			
			_prepareRaceButton.gameObject.SetActive(false);
			_startRaceButton.gameObject.SetActive(false);
			_stopRaceButton.gameObject.SetActive(true);
			_sliderElement.gameObject.SetActive(false);
		}

		private void OnStopRaceButtonClickEventHandler()
		{
			StopRaceEvent?.Invoke();
			
			_prepareRaceButton.gameObject.SetActive(true);
			_startRaceButton.gameObject.SetActive(false);
			_stopRaceButton.gameObject.SetActive(false);
			_sliderElement.gameObject.SetActive(true);
		}
	}
}