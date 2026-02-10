using System;
using StudyProject.ScriptableObjects.BuildingsData;
using StudyProject.UI.BuildingControlPanelScripts;
using UnityEngine;

namespace StudyProject.BuildingLogic
{
	public abstract class InteractableBuilding : MonoBehaviour, IInteractable
	{
		[SerializeField]
		private InteractionController _interactionController;
		
		public event Action<InteractableBuilding> SelectEvent;

		protected BuildingData _buildingData;
		protected BuildingDataAsset _buildingDataAsset;

		public virtual void Initialize(BuildingData buildingData, BuildingDataAsset buildingDataAsset)
		{
			_buildingData = buildingData;
			_buildingDataAsset = buildingDataAsset;
		}

		public void Hover()
		{
			_interactionController.Hover();
		}

		public void UnHover()
		{
			_interactionController.UnHover();
		}

		public virtual void Select()
		{
			SelectEvent?.Invoke(this);
			_interactionController.Select();
		}

		public abstract void SetBuildingPanel(IBuildingControlPanel buildingControlPanel);

		public abstract void CalculateNextDay();
	}
}