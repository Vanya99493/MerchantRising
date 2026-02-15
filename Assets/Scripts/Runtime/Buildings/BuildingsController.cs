using System.Collections.Generic;
using System.Linq;
using StudyProject.ScriptableObjects.BuildingsData;
using StudyProject.ServiceLocatorScripts;
using StudyProject.UI;
using StudyProject.UI.BuildingControlPanelScripts;
using UnityEngine;

namespace StudyProject.BuildingLogic
{
	public class BuildingsController : MonoBehaviour
	{
		[SerializeField]
		private ArtisanBuildingsFactory _artisanBuildingsFactory;
		
		private List<ArtisanInteractableBuilding> _artisanBuildings = new();
		private IBuildingControlPanel _buildingControlPanel;

		private BuildingsCollectionDataAsset _buildingsCollectionDataAsset;

		public void Initialize(List<BuildingData> buildingsData, BuildingsCollectionDataAsset buildingsCollectionDataAsset)
		{
			_buildingsCollectionDataAsset = buildingsCollectionDataAsset;
			
			foreach (var buildingData in buildingsData)
			{
				var artisanBuilding = _artisanBuildingsFactory.CreateArtisanBuilding(buildingData.extractiveBuildingType);
				//TODO: change structure of artisan building initialization to avoid searching needed building data asset every iteration of loop
				artisanBuilding.Initialize(buildingData, _buildingsCollectionDataAsset.BuildingDataAssets.FirstOrDefault(x => x.EtractiveBuildingType == buildingData.extractiveBuildingType)); 
				artisanBuilding.SelectEvent += OnBuildingSelectedEventHandler;
				_artisanBuildings.Add(artisanBuilding);
			}
		}

		private void OnBuildingSelectedEventHandler(InteractableBuilding selectedBuilding)
		{
			IBuildingControlPanel buildingControlPanel = ServiceLocator.Instance.Get<IGameUIManagerService>().BuildingControlPanel;
			selectedBuilding.SetBuildingPanel(buildingControlPanel);
		}
	}
}