using System.Collections.Generic;
using StudyProject.UI;
using UnityEngine;

namespace StudyProject.HelperScripts.UI
{
	public class UIPanelsInitializer : MonoBehaviour
	{
		[SerializeField]
		private List<BasePanel> _panels = new();

		private void Awake()
		{
			InitializePanels();
		}

		private void InitializePanels()
		{
			foreach (var panel in _panels)
			{
				panel.Open();
			}
		}
	}
}