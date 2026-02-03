using StudyProject.CardLogic;
using StudyProject.UI.CardsPairMiniGameScripts;
using UnityEngine;

namespace StudyProject.Entry
{
	public class CardsPairMinGameEntryPoint : MonoBehaviour
	{
		[SerializeField]
		private CardsPairMiniGamePanel _cardsPairMiniGamePanel;

		[SerializeField]
		private CardsController _cardsController;

		private void Awake()
		{
			_cardsPairMiniGamePanel.Open();
			_cardsPairMiniGamePanel.StartMiniGameEvent += PrepareCards;
		}

		private void PrepareCards(int cardsCount)
		{
			if (cardsCount % 2 != 0)
			{
				return;
			}
			
			_cardsController.SpawnCards(cardsCount);
		}
	}
}