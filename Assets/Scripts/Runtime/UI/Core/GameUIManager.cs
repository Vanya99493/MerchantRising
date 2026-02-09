using StudyProject.UI.BuildingControlPanelScripts;
using UnityEngine;

namespace StudyProject.UI
{
	public class GameUIManager : BaseUIManager, IGameUIManagerService
	{
		[SerializeField]
		private BuildingControlPanel _buildingControlPanel;

		public IBuildingControlPanel BuildingControlPanel => _buildingControlPanel;

		public override void CloseAllPanels()
		{
			_buildingControlPanel.Close();
		}
	}
}