using UnityEngine;

namespace StudyProject.ScriptsbleObjects.Application
{
	[CreateAssetMenu(fileName = "AppConfig", menuName = "Scriptable Objects/Application/App Config")]
	public class AppConfig : ScriptableObject
	{
		[field: SerializeField]
		public bool IsDebug { get; private set; }
	}
}