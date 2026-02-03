using System;

namespace StudyProject.Interfaces
{
	public interface IDestroyable<T>
	{
		public event Action<T> DestroyEvent;

		public void Destroy();
	}
}