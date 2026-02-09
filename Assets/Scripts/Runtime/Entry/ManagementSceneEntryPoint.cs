using System.Collections.Generic;
using System.Linq;
using StudyProject.BuildingLogic;
using StudyProject.PlayerScripts;
using StudyProject.ScriptableObjects.BuildingsData;
using StudyProject.ServiceLocatorScripts;
using StudyProject.UI;
using UnityEngine;

namespace StudyProject.Entry
{
	public class ManagementSceneEntryPoint : MonoBehaviour
	{
		[SerializeField]
		private GameUIManager _gameUIManager;

		[SerializeField]
		private TopViewPlayerController _topViewPlayerController;
		
		[SerializeField]
		private BuildingsController _buildingsController;

		[Header("Data Assets")]
		[SerializeField]
		private BuildingsCollectionDataAsset _buildingsCollectionDataAsset;

		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			ServiceLocator.Instance.Register<IGameUIManagerService>(_gameUIManager);
			ServiceLocator.Instance.Register<IPlayerController>(_topViewPlayerController);
			
			_buildingsController.Initialize(GetBuildingsData());
			
			//_gameUIManager.Initialize();
			_gameUIManager.CloseAllPanels();
			
			_topViewPlayerController.ActivateSelection();
		}

		private List<BuildingData> GetBuildingsData()
		{
			return _buildingsCollectionDataAsset.BuildingDataAssets.Select(x => x.BuildingData).ToList();
		}
	}
}