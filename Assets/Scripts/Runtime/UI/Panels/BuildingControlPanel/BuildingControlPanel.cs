using System;
using StudyProject.BuildingLogic;
using StudyProject.PlayerScripts;
using StudyProject.ServiceLocatorScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.BuildingControlPanelScripts
{
	public class BuildingControlPanel : BasePanel, IBuildingControlPanel
	{
		[SerializeField]
		private TMP_Text _buildingNameText;

		[SerializeField]
		private Button _closeButton;

		[Space(10)]
		[SerializeField]
		private TMP_Text _currentLevelText;

		[SerializeField]
		private TMP_Text _currentWorkersAvailableTetx;

		[SerializeField]
		private Button _upgradeButton;

		[SerializeField]
		private TMP_Text _nextLevelText;

		[SerializeField]
		private TMP_Text _nextWorkersAmountText;

		[Space(10)]
		[SerializeField]
		private Image _workerIconImage;

		[SerializeField]
		private TMP_Text _workersSetText;

		[SerializeField]
		private Button _decreaseWorkersButton;

		[SerializeField]
		private Button _increaseWorkersButton;

		[Space(10)]
		[SerializeField]
		private TMP_Text _basicProductionText;

		[SerializeField]
		private TMP_Text _workersProductionText;

		[SerializeField]
		private TMP_Text _generalProductionText;

		[Space(10)]
		[SerializeField]
		private Button _collectButton;

		public event Action CloseEvent;
		public event Action UpgradeEvent;
		public event Action DecreaseWorkersEvent;
		public event Action IncreaseWorkersEvent;
		public event Action CollectEvent;

		public void Open(BuildingPanelData buildingPanelData)
		{
			ServiceLocator.Instance.Get<IPlayerController>().DeactivateSelection();
			
			_buildingNameText.text = buildingPanelData.Name;

			_currentLevelText.text = buildingPanelData.Level.ToString();
			_currentWorkersAvailableTetx.text = buildingPanelData.AvailableWorkers.ToString();

			_nextLevelText.text = buildingPanelData.NextLevel.ToString();
			_nextWorkersAmountText.text = buildingPanelData.NextLevelAvailableWorkers.ToString();

			_workerIconImage.sprite = buildingPanelData.WorkerIcon;
			_workersSetText.text = $"{buildingPanelData.WorkersSet}/{buildingPanelData.AvailableWorkers}";

			_basicProductionText.text = buildingPanelData.BasicProduction.ToString();
			_workersProductionText.text = buildingPanelData.WorkersProduction.ToString();
			_generalProductionText.text = buildingPanelData.GeneralProduction.ToString();

			base.Open();
		}

		public override void Close()
		{
			base.Close();

			CloseEvent = null;
			UpgradeEvent = null;
			DecreaseWorkersEvent = null;
			IncreaseWorkersEvent = null;
			CollectEvent = null;
			
			ServiceLocator.Instance.Get<IPlayerController>().ActivateSelection();
		}

		protected override void SubscribeOnEvents()
		{
			_closeButton.onClick.AddListener(OnCloseButtonClickedEventHandler);
			_upgradeButton.onClick.AddListener(OnUpgradeButtonClickedEventHandler);
			_decreaseWorkersButton.onClick.AddListener(OnDecreaseWorkersButtonClickedEventHandler);
			_increaseWorkersButton.onClick.AddListener(OnIncreaseWorkersButtonClickedEventHandler);
			_collectButton.onClick.AddListener(OnCollectButtonClickedEventHandler);
		}

		protected override void UnsubscribeFromEvents()
		{
			_closeButton.onClick.RemoveListener(OnCloseButtonClickedEventHandler);
			_upgradeButton.onClick.RemoveListener(OnUpgradeButtonClickedEventHandler);
			_decreaseWorkersButton.onClick.RemoveListener(OnDecreaseWorkersButtonClickedEventHandler);
			_increaseWorkersButton.onClick.RemoveListener(OnIncreaseWorkersButtonClickedEventHandler);
			_collectButton.onClick.RemoveListener(OnCollectButtonClickedEventHandler);
		}

		private void OnCloseButtonClickedEventHandler()
		{
			CloseEvent?.Invoke();
		}

		private void OnUpgradeButtonClickedEventHandler()
		{
			UpgradeEvent?.Invoke();
		}

		private void OnDecreaseWorkersButtonClickedEventHandler()
		{
			DecreaseWorkersEvent?.Invoke();
		}

		private void OnIncreaseWorkersButtonClickedEventHandler()
		{
			IncreaseWorkersEvent?.Invoke();
		}

		private void OnCollectButtonClickedEventHandler()
		{
			CollectEvent?.Invoke();
		}
	}
}