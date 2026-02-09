using System.Collections.Generic;
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

		public void Initialize(List<BuildingData> buildingsData)
		{
			foreach (var buildingData in buildingsData)
			{
				var artisanBuilding = _artisanBuildingsFactory.CreateArtisanBuilding(buildingData.BuildingType);
				artisanBuilding.Initialize(buildingData);
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