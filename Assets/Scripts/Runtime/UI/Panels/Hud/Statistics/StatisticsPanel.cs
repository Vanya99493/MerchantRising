using StudyProject.UI.UIAnimation;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.HudPanelScripts
{
	public class StatisticsPanel : BasePanel
	{
		[SerializeField]
		private Button _openCloseButton;

		[SerializeField]
		private MoveAnimationElement _moveAnimationElement;
		
		[SerializeField]
		private CanvasGroup _interactionBlocker;
		
		public override void Open()
		{
			base.Open();
			
			_moveAnimationElement.Initialize(false);
		}

		protected override void SubscribeOnEvents()
		{
			base.SubscribeOnEvents();
			
			_openCloseButton.onClick.AddListener(OnOpenCloseButtonClickedEventHandler);
		}

		protected override void UnsubscribeFromEvents()
		{
			base.UnsubscribeFromEvents();
			
			_openCloseButton.onClick.RemoveListener(OnOpenCloseButtonClickedEventHandler);
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
	}
}