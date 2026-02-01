using System;

namespace StudyProject.UI.RacingPanelScripts
{
	public interface IRacingPanel
	{
		public event Action<int> PrepareRaceEvent;
		public event Action StartRaceEvent;
		public event Action StopRaceEvent;
	}
}