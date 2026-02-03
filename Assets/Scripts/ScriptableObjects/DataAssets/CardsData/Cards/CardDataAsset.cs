using StudyProject.CardLogic;
using UnityEngine;

namespace StudyProject.ScriptableObjects.CardsData
{
	[CreateAssetMenu(fileName = "CardDataAsset", menuName = "Scriptable Objects/Data Assets/Cards/Card Data Asset")]
	public class CardDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public string Name;

		[field: SerializeField]
		public int Id;

		[field: SerializeField]
		public Texture RuneTexture;

		public CardData GetCardData()
		{
			return new CardData()
			{
				Name = Name,
				Id = Id,
				RuneTexture = RuneTexture
			};
		}
	}
}