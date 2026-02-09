using StudyProject.ServiceLocatorScripts;

namespace StudyProject.PlayerScripts
{
	public interface IPlayerController : IService
	{
		public void ActivateSelection();
		public void DeactivateSelection();
	}
}