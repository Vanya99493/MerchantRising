using UnityEngine;

namespace StudyProject.Extensions
{
	public static class MonoBehaviourExtensions
	{
		public static void KillCoroutine(this MonoBehaviour gameObject, ref Coroutine coroutine)
		{
			if (gameObject != null && coroutine != null)
			{
				gameObject.StopCoroutine(coroutine);
			}

			coroutine = null;
		}
	}
}