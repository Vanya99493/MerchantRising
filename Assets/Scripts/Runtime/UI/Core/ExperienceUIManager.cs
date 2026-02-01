using StudyProject.UI.RacingPanelScripts;
using UnityEngine;

namespace StudyProject.UI
{
	public class ExperienceUIManager : BaseUIManager
	{
		[SerializeField]
		private RacingPanel _racingPanel;

		public IRacingPanel RacingPanel => _racingPanel;

		public void OpenRacingPanel() => _racingPanel.Open();
		public void CloseRacingPanel() => _racingPanel.Close();
	}
}