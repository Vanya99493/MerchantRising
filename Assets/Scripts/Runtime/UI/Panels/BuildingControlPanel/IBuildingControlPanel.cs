using System;
using StudyProject.BuildingLogic;

namespace StudyProject.UI.BuildingControlPanelScripts
{
	public interface IBuildingControlPanel
	{
		public event Action CloseEvent;
		public event Action UpgradeEvent;
		public event Action<WorkerType> DecreaseWorkersEvent;
		public event Action<WorkerType> IncreaseWorkersEvent;
		public event Action CollectEvent;

		public void Open(BuildingPanelData buildingPanelData);
		public void Close();
	}
}