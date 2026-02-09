using StudyProject.UI.RacingPanelScripts;
using UnityEngine;

namespace StudyProject.UI
{
	public class RacingUIManager : BaseUIManager
	{
		[SerializeField]
		private RacingPanel _racingPanel;

		public IRacingPanel RacingPanel => _racingPanel;
		
		public override void CloseAllPanels()
		{
			CloseRacingPanel();
		}

		public void OpenRacingPanel() => _racingPanel.Open();
		public void CloseRacingPanel() => _racingPanel.Close();
	}
}