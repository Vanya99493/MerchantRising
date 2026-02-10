using UnityEngine;

namespace ScriptableObjects.DataAssets.Outline
{
	[CreateAssetMenu(fileName = "OutlineDataAsset", menuName = "Scriptable Objects/Data Assets/Outline/Outline Data Asset")]
	public class OutlineDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public StudyProject.Utils.Outline.Mode OutlineMode { get; private set; }
		
		[field: SerializeField]
		public Color OutlineColor { get; private set; }
		
		[field: SerializeField, Range(0f, 10f)]
		public float OutlineWidth { get; private set; }
	}
}