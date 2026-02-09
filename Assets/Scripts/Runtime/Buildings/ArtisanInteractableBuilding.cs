using StudyProject.PlayerScripts;
using StudyProject.ServiceLocatorScripts;
using StudyProject.UI.BuildingControlPanelScripts;

namespace StudyProject.BuildingLogic
{
	public class ArtisanInteractableBuilding : InteractableBuilding
	{
		private int _buildingStorage;

		private IBuildingControlPanel _buildingControlPanel;
		
		public override void Initialize(BuildingData buildingData)
		{
			base.Initialize(buildingData);
		}

		public override void SetBuildingPanel(IBuildingControlPanel buildingControlPanel)
		{
			_buildingControlPanel = buildingControlPanel;
			
			_buildingControlPanel.CloseEvent += OnCloseEventHandler;
			_buildingControlPanel.UpgradeEvent += OnUpgradeEventHandler;
			_buildingControlPanel.DecreaseWorkersEvent += OnDecreaseWorkersEventHandler;
			_buildingControlPanel.IncreaseWorkersEvent += OnIncreaseWorkersEventHandler;
			_buildingControlPanel.CollectEvent += OnCollectEventHandler;
			
			_buildingControlPanel.Open(GenerateBuildingPanelData());
		}

		public override void CalculateNextDay()
		{
			//TODO: add calculation of new day
		}

		private void OnCloseEventHandler()
		{
			_buildingControlPanel.Close();
			_buildingControlPanel = null;
		}

		private void OnUpgradeEventHandler()
		{
			
		}

		private void OnDecreaseWorkersEventHandler()
		{
			
		}

		private void OnIncreaseWorkersEventHandler()
		{
			
		}

		private void OnCollectEventHandler()
		{
			
		}

		private BuildingPanelData GenerateBuildingPanelData()
		{
			return new BuildingPanelData();
		}
	}
}