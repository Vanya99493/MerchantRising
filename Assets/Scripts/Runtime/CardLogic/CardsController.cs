using System.Collections;
using System.Collections.Generic;
using StudyProject.Extensions;
using StudyProject.ScriptableObjects.CardsData;
using UnityEngine;

namespace StudyProject.CardLogic
{
	public class CardsController : MonoBehaviour
	{
		[SerializeField]
		private CardsFactory _cardsFactory;

		[SerializeField]
		private CameraRaycaster _cameraRaycaster;

		[SerializeField]
		private CardsArrangementCalculator _cardsArrangementCalculator;

		[SerializeField]
		private CameraController _cameraController;
		
		[Header("Settings")]
		[SerializeField]
		private float _cardsCheckingDelay = 2f;

		[SerializeField]
		private float _cardsReturningDelay = 0.75f;

		[SerializeField]
		private float _cardsDeactivatingDelay = 0f;

		[Header("Data Assets")]
		[SerializeField]
		private CardsCollectionDataAsset _cardsCollectionDataAsset;

		private List<CardBase> _spawnedCards = new();
		private CardBase _selectedCard;

		public void SpawnCards(int cardsCount)
		{
			_cameraController.StartMovement();
			
			ClearSpawnedCards();
			
			var cardsPositions = _cardsArrangementCalculator.CalculateCardsArrangement(cardsCount);
			var cardsData = _cardsCollectionDataAsset.Cards.GetRandomAmount(cardsCount / 2);
			
			foreach (var cardData in cardsData)
			{
				for (int i = 0; i < 2; i++)
				{
					var card = _cardsFactory.InstantiateNewCard(cardsPositions.Pick(Random.Range(0, cardsPositions.Count)), Quaternion.Euler(0f, 0f, 180f), cardData.GetCardData());
					card.SelectEvent += OnCardSelectEventHandler;
					_spawnedCards.Add(card);
				}
			}
		}

		private void OnCardSelectEventHandler(CardBase cardBase)
		{
			if (_selectedCard == null)
			{
				_selectedCard = cardBase;
			}
			else
			{
				DeactivateCameraRaycaster();
				StartCoroutine(CheckAfterDelay(cardBase));
			}
		}

		private IEnumerator CheckAfterDelay(CardBase cardBase)
		{
			yield return new WaitForSeconds(_cardsCheckingDelay);
			
			if (_selectedCard.CardData.Id == cardBase.CardData.Id)
			{
				Debug.Log("+1");
				
				_selectedCard.Deactivate();
				cardBase.Deactivate();
				
				_selectedCard = null;

				yield return new WaitForSeconds(_cardsDeactivatingDelay);
				ActivateCameraRaycaster();
			}
			else
			{
				_selectedCard.SwapCard(false);
				cardBase.SwapCard(false);
				
				_selectedCard = null;
				
				yield return new WaitForSeconds(_cardsReturningDelay);
				ActivateCameraRaycaster();
			}
		}

		private void ActivateCameraRaycaster()
		{
			_cameraRaycaster.enabled = true;
		}

		private void DeactivateCameraRaycaster()
		{
			_cameraRaycaster.enabled = false;
		}

		private void ClearSpawnedCards()
		{
			foreach (var spawnedCard in _spawnedCards)
			{
				spawnedCard.Destroy();
			}
			_spawnedCards.Clear();
		}
	}
}