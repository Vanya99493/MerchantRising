using UnityEngine;

namespace StudyProject.UI
{
	public abstract class BaseUIManager : MonoBehaviour
	{
		//[SerializeField]
		//private PopupsManager _popupsManager;
		
		public abstract void CloseAllPanels();
	}
}