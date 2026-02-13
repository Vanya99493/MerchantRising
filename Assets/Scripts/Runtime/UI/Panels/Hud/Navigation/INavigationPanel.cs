using System;

namespace StudyProject.UI.HudPanelScripts
{
	public interface INavigationPanel
	{
		public event Action OpenInventoryEvent;
		public event Action OpenMarketEvent;
		public event Action OpenWorkersMarketEvent;
	}
}