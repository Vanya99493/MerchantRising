using System;
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

		public virtual void Initialize(BuildingData buildingData)
		{
			_buildingData = buildingData;
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