using StudyProject.Constants;
using StudyProject.Enums;
using UnityEngine;

namespace StudyProject.RaceLogic
{
	public class SimpleCharacterColorController : MonoBehaviour
	{
		private const string BASE_COLOR_NAME = "_BaseColor";
		
		[SerializeField]
		private Renderer _characterRender;
		
		public void Initialize(ColorType colorType)
		{
			Color color = CollectionsContainer.RGBColors[colorType];
			MaterialPropertyBlock block = new MaterialPropertyBlock();
			
			int materialCount = _characterRender.sharedMaterials.Length;
			for (int i = 0; i < materialCount; i++)
			{
				_characterRender.GetPropertyBlock(block);
				block.SetColor(BASE_COLOR_NAME, color);
				_characterRender.SetPropertyBlock(block);
			}
		}
	}
}