using StudyProject.ServiceLocatorScripts;
using StudyProject.UI.BuildingControlPanelScripts;

namespace StudyProject.UI
{
	public interface IGameUIManagerService : IService
	{
		public IBuildingControlPanel BuildingControlPanel { get; }
	}
}