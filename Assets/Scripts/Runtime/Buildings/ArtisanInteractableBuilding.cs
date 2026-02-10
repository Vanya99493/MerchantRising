using System.Collections.Generic;
using System.Linq;
using StudyProject.Extensions;
using StudyProject.ScriptableObjects.BuildingsData;
using StudyProject.UI.BuildingControlPanelScripts;

namespace StudyProject.BuildingLogic
{
	public class ArtisanInteractableBuilding : InteractableBuilding
	{
		private int _buildingStorage;

		private IBuildingControlPanel _buildingControlPanel;
		
		public override void Initialize(BuildingData buildingData, BuildingDataAsset buildingDataAsset)
		{
			base.Initialize(buildingData, buildingDataAsset);
		}

		public override void SetBuildingPanel(IBuildingControlPanel buildingControlPanel)
		{
			_buildingControlPanel = buildingControlPanel;
			
			_buildingControlPanel.CloseEvent += OnCloseEventHandler;
			_buildingControlPanel.UpgradeEvent += OnUpgradeEventHandler;
			_buildingControlPanel.DecreaseWorkersEvent += OnDecreaseWorkersEventHandler;
			_buildingControlPanel.IncreaseWorkersEvent += OnIncreaseWorkersEventHandler;
			_buildingControlPanel.CollectEvent += OnCollectEventHandler;
			
			OpenBuildingControlPanel();
		}

		public override void CalculateNextDay()
		{
			//TODO: add calculation of new day
		}

		private void OpenBuildingControlPanel()
		{
			_buildingControlPanel.Open(GenerateBuildingPanelData());
		}

		private void OnCloseEventHandler()
		{
			_buildingControlPanel.Close();
			_buildingControlPanel = null;
		}

		private void OnUpgradeEventHandler()
		{
			//TODO: add request to upgrade building
		}

		private void OnDecreaseWorkersEventHandler(WorkerType workerType)
		{
			var workersOfTypeData = _buildingData.WorkersNumberData.FirstOrDefault(x => x.WorkerType == workerType);
			
			if (workersOfTypeData.WorkersCount > 0)
			{
				workersOfTypeData.WorkersCount -= 1;
				OpenBuildingControlPanel();
			}
		}

		private void OnIncreaseWorkersEventHandler(WorkerType workerType)
		{
			var workersOfTypeData = _buildingData.WorkersNumberData.FirstOrDefault(x => x.WorkerType == workerType);
			
			var currentLevelData = _buildingDataAsset.UpgradesData.UpgradeLevelsData.FirstOrDefault(x => x.Level == _buildingData.CurrentLevel);
			var maximalWorkersCount = currentLevelData.AvailableWorkers.FirstOrDefault(x => x.WorkerType == workerType).WorkersCount;
			
			if (workersOfTypeData.WorkersCount < maximalWorkersCount)
			{
				workersOfTypeData.WorkersCount += 1;
				OpenBuildingControlPanel();
			}
		}

		private void OnCollectEventHandler()
		{
			//TODO: add collecting of product and adding it into the inventory (storage)
		}

		private BuildingPanelData GenerateBuildingPanelData()
		{
			List<BuildingPanelWorkersOfTypeData> buildingPanelWorkersOfTypesData = new();

			UpgradeLevelData currentLevelData = _buildingDataAsset.UpgradesData.UpgradeLevelsData.FirstOrDefault(x => x.Level == _buildingData.CurrentLevel);
			foreach (var workerData in _buildingDataAsset.WorkersData)
			{
				buildingPanelWorkersOfTypesData.Add(new BuildingPanelWorkersOfTypeData()
				{
					Name = workerData.Name,
					WorkerType = workerData.WorkerType,
					WorkerIcon = workerData.Icon,
					WorkerMaintenance = workerData.WorkerMaintenance,
					SetWorkers = _buildingData.WorkersNumberData.FirstOrDefault(x => x.WorkerType == workerData.WorkerType).WorkersCount,
					MaximalWorkersNumber = currentLevelData.AvailableWorkers.FirstOrDefault(x => x.WorkerType == workerData.WorkerType).WorkersCount,
					NextLevelMaximalWorkersNumber = _buildingDataAsset.UpgradesData.UpgradeLevelsData.FirstOrDefault(x => x.Level == _buildingData.CurrentLevel + 1).AvailableWorkers.FirstOrDefault(x => x.WorkerType == workerData.WorkerType).WorkersCount
				});
			}

			BuildingPanelData buildingPanelData = new()
			{
				Name = _buildingData.Name,
				Level = _buildingData.CurrentLevel,
				NextLevel = _buildingDataAsset.UpgradesData.UpgradeLevelsData.Last().Level == _buildingData.CurrentLevel 
					? -1
					: _buildingData.CurrentLevel + 1,
				UpgradeToNextLevelCost = currentLevelData.UpgradeToNextLevelCost,
				WorkersTypeData = buildingPanelWorkersOfTypesData,
				BasicProduction = GetBasicProduction(),
				WorkersProduction = GetWorkersProduction(),
				GeneralProduction = GetGeneralProduction(),
			};
			
			return buildingPanelData;
		}

		private int GetBasicProduction()
		{
			return _buildingDataAsset.UpgradesData.UpgradeLevelsData.FirstOrDefault(x => x.Level == _buildingData.CurrentLevel).BasicProduction;
		}

		private int GetWorkersProduction()
		{
			int production = 0;
			foreach (var workersOfTypeData in _buildingData.WorkersNumberData)
			{
				production += _buildingDataAsset.WorkersData.FirstOrDefault(x => x.WorkerType == workersOfTypeData.WorkerType).WorkerProduction * workersOfTypeData.WorkersCount;
			}

			return production;
		}

		private int GetGeneralProduction()
		{
			return GetBasicProduction() + GetWorkersProduction();
		}
	}
}