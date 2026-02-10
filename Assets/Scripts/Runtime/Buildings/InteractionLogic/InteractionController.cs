using System.Collections.Generic;
using ScriptableObjects.DataAssets.Outline;
using StudyProject.Utils;
using UnityEngine;

namespace StudyProject.BuildingLogic
{
	public class InteractionController : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> _modelGameObjects = new();

		[SerializeField]
		private OutlineDataAsset _outlineDataAsset;

		public void Hover()
		{
			foreach (var modelGameObject in _modelGameObjects)
			{
				var outline = modelGameObject.AddComponent<Outline>();
				outline.SetOutlineData(_outlineDataAsset.OutlineMode, _outlineDataAsset.OutlineColor, _outlineDataAsset.OutlineWidth);
			}
		}

		public void UnHover()
		{
			foreach (var modelGameObject in _modelGameObjects)
			{
				if (modelGameObject.TryGetComponent(out Outline outline))
				{
					Destroy(outline);
				}
			}
		}

		public void Select()
		{
			UnHover();
		}
	}
}