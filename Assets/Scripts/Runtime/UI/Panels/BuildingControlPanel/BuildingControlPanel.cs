using System;
using System.Collections.Generic;
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
		private TMP_Text _nextLevelText;

		[SerializeField]
		private TMP_Text _currentWorkersAvailableText;

		[SerializeField]
		private TMP_Text _nextLevelWorkersAmountText;

		[SerializeField]
		private Button _upgradeButton;

		[SerializeField]
		private TMP_Text _upgradeCostText;

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

		[Space(20)]
		[SerializeField]
		private TypeOfWorkersElementsFactory _typeOfWorkersElementsFactory;

		public event Action CloseEvent;
		public event Action UpgradeEvent;
		public event Action<WorkerType> DecreaseWorkersEvent;
		public event Action<WorkerType> IncreaseWorkersEvent;
		public event Action CollectEvent;

		public void Open(BuildingPanelData buildingPanelData)
		{
			ServiceLocator.Instance.Get<IPlayerController>().DeactivateSelection();
			
			_buildingNameText.text = buildingPanelData.Name;

			_currentLevelText.text = $"Рівень {buildingPanelData.Level}";
			_nextLevelText.text = $"Рівень {buildingPanelData.NextLevel}";

			string currentWorkersAvailableString = "";
			foreach (var buildingPanelWorkersOfTypeData in buildingPanelData.WorkersTypeData)
			{
				if (buildingPanelWorkersOfTypeData.MaximalWorkersNumber > 0)
				{
					currentWorkersAvailableString += $"{buildingPanelWorkersOfTypeData.Name}: {buildingPanelWorkersOfTypeData.MaximalWorkersNumber}\n";
				}
				else
				{
					break;
				}
			}
			_currentWorkersAvailableText.text = currentWorkersAvailableString;

			string nextLevelWorkersAvailableString = "";
			foreach (var buildingPanelWorkersOfTypeData in buildingPanelData.WorkersTypeData)
			{
				if (buildingPanelWorkersOfTypeData.NextLevelMaximalWorkersNumber > 0)
				{
					nextLevelWorkersAvailableString += $"{buildingPanelWorkersOfTypeData.Name}: {buildingPanelWorkersOfTypeData.NextLevelMaximalWorkersNumber}\n";
				}
				else
				{
					break;
				}
			}
			_nextLevelWorkersAmountText.text = nextLevelWorkersAvailableString;

			_upgradeCostText.text = buildingPanelData.UpgradeToNextLevelCost.ToString();

			InitializeWorkersElement(buildingPanelData.WorkersTypeData);

			_basicProductionText.text = buildingPanelData.BasicProduction.ToString();
			_workersProductionText.text = buildingPanelData.WorkersProduction.ToString();
			_generalProductionText.text = buildingPanelData.GeneralProduction.ToString();

			base.Open();
		}

		public override void Close()
		{
			base.Close();

			_typeOfWorkersElementsFactory.DestroyAllTypeOfWorkersElements();

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
			
			_collectButton.onClick.AddListener(OnCollectButtonClickedEventHandler);
		}

		protected override void UnsubscribeFromEvents()
		{
			_closeButton.onClick.RemoveListener(OnCloseButtonClickedEventHandler);
			_upgradeButton.onClick.RemoveListener(OnUpgradeButtonClickedEventHandler);
			
			_collectButton.onClick.RemoveListener(OnCollectButtonClickedEventHandler);
		}

		private void InitializeWorkersElement(List<BuildingPanelWorkersOfTypeData> workersOfTypesData)
		{
			_typeOfWorkersElementsFactory.DestroyAllTypeOfWorkersElements();
			foreach (var buildingPanelWorkersOfTypeData in workersOfTypesData)
			{
				if (buildingPanelWorkersOfTypeData.MaximalWorkersNumber > 0)
				{
					var typeOfWorkersElement = _typeOfWorkersElementsFactory.InstantiateTypeOfWorkersElement();
					typeOfWorkersElement.Initialize(buildingPanelWorkersOfTypeData, OnDecreaseWorkersButtonClickedEventHandler, OnIncreaseWorkersButtonClickedEventHandler);
				}
			}
		}

		private void OnCloseButtonClickedEventHandler()
		{
			CloseEvent?.Invoke();
		}

		private void OnUpgradeButtonClickedEventHandler()
		{
			UpgradeEvent?.Invoke();
		}

		private void OnDecreaseWorkersButtonClickedEventHandler(WorkerType workerType)
		{
			DecreaseWorkersEvent?.Invoke(workerType);
		}

		private void OnIncreaseWorkersButtonClickedEventHandler(WorkerType workerType)
		{
			IncreaseWorkersEvent?.Invoke(workerType);
		}

		private void OnCollectButtonClickedEventHandler()
		{
			CollectEvent?.Invoke();
		}
	}
}