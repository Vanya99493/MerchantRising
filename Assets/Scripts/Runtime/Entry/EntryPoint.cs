using StudyProject.RaceLogic;
using StudyProject.UI;
using UnityEngine;

namespace StudyProject.Entry
{
	public class EntryPoint : MonoBehaviour
	{
		[SerializeField]
		private RaceController _raceController;

		[SerializeField]
		private RacingUIManager _uiManager;

		public void Awake()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			_raceController.Initialize(_uiManager.RacingPanel);
			
			_uiManager.OpenRacingPanel();
		}
	}
}