using System;
using StudyProject.UI.BuildingControlPanelScripts;
using UnityEngine;

namespace StudyProject.BuildingLogic
{
	public abstract class InteractableBuilding : MonoBehaviour, IInteractable
	{
		[SerializeField]
		private GameObject _gameObject;
		
		public event Action<InteractableBuilding> SelectEvent;

		protected BuildingData _buildingData;

		public virtual void Initialize(BuildingData buildingData)
		{
			_buildingData = buildingData;
		}

		public void Hover()
		{
			_gameObject.AddComponent<Outline>();
		}

		public void UnHover()
		{
			if (_gameObject.TryGetComponent(out Outline outline))
			{
				Destroy(outline);
			}
		}

		public virtual void Select()
		{
			SelectEvent?.Invoke(this);
			UnHover();
		}

		public abstract void SetBuildingPanel(IBuildingControlPanel buildingControlPanel);

		public abstract void CalculateNextDay();
	}
}