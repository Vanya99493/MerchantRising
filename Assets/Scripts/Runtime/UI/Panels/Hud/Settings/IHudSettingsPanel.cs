using System;

namespace StudyProject.UI.HudPanelScripts
{
	public interface IHudSettingsPanel
	{
		public event Action OpenMenuPanelEvent;
		public event Action OpenSettingsPanelEvent;
		public event Action OpenSaveLoadPanelEvent;
	}
}