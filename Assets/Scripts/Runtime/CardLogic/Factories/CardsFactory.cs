using UnityEngine;

namespace StudyProject.CardLogic
{
	public class CardsFactory : MonoBehaviour
	{
		[SerializeField]
		private CardBase _cardBasePrefab;

		[SerializeField]
		private Transform _cardsParentTransform;

		public CardBase InstantiateNewCard(Vector3 position, Quaternion rotation, CardData cardData)
		{
			var card = Instantiate(_cardBasePrefab, _cardsParentTransform);
			card.transform.localPosition = position;
			card.transform.localRotation = rotation;
			card.Initialize(cardData);
			card.DestroyEvent += DestroyRacer;
			return card;
		}

		private void DestroyRacer(CardBase card)
		{
			Destroy(card.gameObject);
		}
	}
}