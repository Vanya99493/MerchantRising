using UnityEngine;

namespace StudyProject.UI
{
	public abstract class BaseUIManager : MonoBehaviour
	{
		//[SerializeField]
		//private PopupsManager _popupsManager;

		public virtual void Initialize()
		{
			CloseAllPanels();
		}
		
		public abstract void CloseAllPanels();
	}
}