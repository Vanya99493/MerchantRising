using System;

namespace StudyProject.RaceLogic
{
	public interface IDestroyable<T>
	{
		public event Action<T> DestroyEvent;

		public void Destroy();
	}
}