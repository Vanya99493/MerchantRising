using System;
using StudyProject.UI.UIAnimation;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.HudPanelScripts
{
	public class HudSettingsPanel : BasePanel
	{
		[SerializeField]
		private Button _openCloseButton;

		[SerializeField]
		private MoveAnimationElement _moveAnimationElement;

		[SerializeField]
		private Button _menuButton;

		[SerializeField]
		private Button _settingsButton;

		[SerializeField]
		private Button _saveLoadButton;

		[SerializeField]
		private CanvasGroup _interactionBlocker;

		public event Action OpenMenuPanelEvent;
		public event Action OpenSettingsPanelEvent;
		public event Action OpenSaveLoadPanelEvent;

		public override void Open()
		{
			base.Open();
			
			_moveAnimationElement.Initialize(true);
		}

		protected override void SubscribeOnEvents()
		{
			base.SubscribeOnEvents();
			
			_openCloseButton.onClick.AddListener(OnOpenCloseButtonClickedEventHandler);
			
			_menuButton.onClick.AddListener(OnMenuButtonClickedEventHandler);
			_settingsButton.onClick.AddListener(OnSettingsButtonClickedEventHandler);
			_saveLoadButton.onClick.AddListener(OnSaveLoadButtonClickedEventHandler);
		}

		protected override void UnsubscribeFromEvents()
		{
			base.UnsubscribeFromEvents();
			
			_openCloseButton.onClick.RemoveListener(OnOpenCloseButtonClickedEventHandler);
			
			_menuButton.onClick.RemoveListener(OnMenuButtonClickedEventHandler);
			_settingsButton.onClick.RemoveListener(OnSettingsButtonClickedEventHandler);
			_saveLoadButton.onClick.RemoveListener(OnSaveLoadButtonClickedEventHandler);
		}

		private void BlockInteraction()
		{
			_interactionBlocker.blocksRaycasts = true;
		}

		private void UnblockInteraction()
		{
			_interactionBlocker.blocksRaycasts = false;
		}

		private void OnOpenCloseButtonClickedEventHandler()
		{
			BlockInteraction();
			_moveAnimationElement.StartAnimation(UnblockInteraction);
		}

		private void OnMenuButtonClickedEventHandler()
		{
			OpenMenuPanelEvent?.Invoke();
		}

		private void OnSettingsButtonClickedEventHandler()
		{
			OpenSettingsPanelEvent?.Invoke();
		}

		private void OnSaveLoadButtonClickedEventHandler()
		{
			OpenSaveLoadPanelEvent?.Invoke();
		}
	}
}