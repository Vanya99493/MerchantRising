using System;
using StudyProject.BuildingLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.BuildingControlPanelScripts
{
	public class TypeOfWorkersElement : MonoBehaviour, IDestroyableElement<TypeOfWorkersElement>
	{
		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private Button _decreaseButton;

		[SerializeField]
		private Button _increaseButton;

		[SerializeField]
		private TMP_Text _workersSetText;

		[SerializeField]
		private TMP_Text _maintenanceText;
		
		public event Action<TypeOfWorkersElement> DestroyEvent;

		public void Initialize(BuildingPanelWorkersOfTypeData buildingPanelWorkersOfTypeData, Action<WorkerType> onDecreaseButtonClickedEventHandler = null, Action<WorkerType> onIncreaseButtonClickedEventHandler = null)
		{
			_iconImage.sprite = buildingPanelWorkersOfTypeData.WorkerIcon;
			_workersSetText.text = $"{buildingPanelWorkersOfTypeData.SetWorkers}/{buildingPanelWorkersOfTypeData.MaximalWorkersNumber}";

			_decreaseButton.interactable = buildingPanelWorkersOfTypeData.SetWorkers > 0;
			_increaseButton.interactable = buildingPanelWorkersOfTypeData.SetWorkers < buildingPanelWorkersOfTypeData.MaximalWorkersNumber;
			
			_maintenanceText.text = buildingPanelWorkersOfTypeData.WorkerMaintenance.ToString();
			
			_decreaseButton.onClick.RemoveAllListeners();
			_decreaseButton.onClick.AddListener(() => onDecreaseButtonClickedEventHandler?.Invoke(buildingPanelWorkersOfTypeData.WorkerType));
			
			_increaseButton.onClick.RemoveAllListeners();
			_increaseButton.onClick.AddListener(() => onIncreaseButtonClickedEventHandler?.Invoke(buildingPanelWorkersOfTypeData.WorkerType));
		}

		public void Destroy()
		{
			DestroyEvent?.Invoke(this);
		}
	}
}