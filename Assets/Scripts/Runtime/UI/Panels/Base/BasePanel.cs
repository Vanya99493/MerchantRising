using UnityEngine;

namespace StudyProject.UI
{
	public abstract class BasePanel : MonoBehaviour
	{
		public virtual void Open()
		{
			SubscribeOnEvents();
		}

		public virtual void Close()
		{
			UnsubscribeFromEvents();
		}

		protected virtual void SubscribeOnEvents() { }
		protected virtual void UnsubscribeFromEvents() { }
	}
}