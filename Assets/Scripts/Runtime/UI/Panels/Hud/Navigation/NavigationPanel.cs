using System;
using StudyProject.UI.UIAnimation;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.HudPanelScripts
{
	public class NavigationPanel : BasePanel
	{
		[SerializeField]
		private Button _openCloseButton;

		[SerializeField]
		private MoveAnimationElement _moveAnimationElement;

		[SerializeField]
		private Button _inventoryButton;

		[SerializeField]
		private Button _marketButton;

		[SerializeField]
		private Button _workersMarketButton;

		[SerializeField]
		private CanvasGroup _interactionBlocker;

		public event Action OpenInventoryEvent;
		public event Action OpenMarketEvent;
		public event Action OpenWorkersMarketEvent;
		
		public override void Open()
		{
			base.Open();
			
			_moveAnimationElement.Initialize(true);
		}

		protected override void SubscribeOnEvents()
		{
			base.SubscribeOnEvents();
			
			_openCloseButton.onClick.AddListener(OnOpenCloseButtonClickedEventHandler);
			
			_inventoryButton.onClick.AddListener(OnInventoryButtonClickedEventHandler);
			_marketButton.onClick.AddListener(OnMarketButtonClickedEventHandler);
			_workersMarketButton.onClick.AddListener(OnWorkersMarketButtonClickedEventHandler);
		}

		protected override void UnsubscribeFromEvents()
		{
			base.UnsubscribeFromEvents();
			
			_openCloseButton.onClick.RemoveListener(OnOpenCloseButtonClickedEventHandler);
			
			_inventoryButton.onClick.RemoveListener(OnInventoryButtonClickedEventHandler);
			_marketButton.onClick.RemoveListener(OnMarketButtonClickedEventHandler);
			_workersMarketButton.onClick.RemoveListener(OnWorkersMarketButtonClickedEventHandler);
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

		private void OnInventoryButtonClickedEventHandler()
		{
			OpenInventoryEvent?.Invoke();
		}

		private void OnMarketButtonClickedEventHandler()
		{
			OpenMarketEvent?.Invoke();
		}

		private void OnWorkersMarketButtonClickedEventHandler()
		{
			OpenWorkersMarketEvent?.Invoke();
		}
	}
}