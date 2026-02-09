using UnityEngine;

namespace StudyProject.UI
{
	public abstract class BasePanel : MonoBehaviour
	{
		public bool IsOpen { get; protected set; }
		
		public virtual void Open()
		{
			if (!IsOpen)
			{
				SubscribeOnEvents();
				IsOpen = true;
				gameObject.SetActive(true);
			}
		}

		public virtual void Close()
		{
			UnsubscribeFromEvents();
			IsOpen = false;
			gameObject.SetActive(false);
		}

		protected virtual void SubscribeOnEvents() { }
		protected virtual void UnsubscribeFromEvents() { }
	}
}