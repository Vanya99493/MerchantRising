using System;

namespace StudyProject.UI
{
	public interface IDestroyableElement<T>
	{
		public event Action<T> DestroyEvent;

		public void Destroy();
	}
}