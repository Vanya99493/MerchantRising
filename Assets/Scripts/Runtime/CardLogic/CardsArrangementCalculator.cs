using System.Collections.Generic;
using StudyProject.Utils;
using UnityEngine;

namespace StudyProject.CardLogic
{
	public class CardsArrangementCalculator : MonoBehaviour
	{
		[SerializeField]
		private int _minRowsCount = 2;
		
		[SerializeField]
		private int _maxRowsCount = 4;

		[SerializeField]
		private int _minColumnsCount = 2;
		
		[SerializeField]
		private int _maxColumnsCount = 8;

		[SerializeField]
		private float _horizontalSpacing = 0.09f;

		[SerializeField]
		private float _verticalSpacing = 0.12f;
		
		public List<Vector3> CalculateCardsArrangement(int cardsCount)
		{
			var arrangement = CalculateBestArrangement(cardsCount);
			return CalculateArrangement(arrangement.FirstValue, arrangement.SecondValue, cardsCount);
		}

		private Pair<int, int> CalculateBestArrangement(int cardsCount)
		{
			List<Pair<int, int>> possibleRectangularArrangements = new();
			List<Pair<int, int>> possibleAlternativeArrangements = new();

			int product;
			for (int i = _minRowsCount; i <= _maxRowsCount; i++)
			{
				for (int j = _minColumnsCount; j <= _maxColumnsCount; j++)
				{
					product = i * j;
					if (product == cardsCount)
					{
						possibleRectangularArrangements.Add(new(i, j));
					}
					else if(product > cardsCount && j % 2 == 0 && product - i < cardsCount)
					{
						possibleAlternativeArrangements.Add(new(i, j));
					}
				}
			}

			return possibleRectangularArrangements.Count > 0
				? possibleRectangularArrangements[Random.Range(0, possibleRectangularArrangements.Count)]
				: possibleAlternativeArrangements[Random.Range(0, possibleAlternativeArrangements.Count)];
		}

		private List<Vector3> CalculateArrangement(int rowsCount, int columnsCount, int cardsCount)
		{
			List<Vector3> cardsArrangementList = new();
			int cardsLeft = cardsCount;
			float firstRowPosition = _verticalSpacing / 2f * (rowsCount + 1) - _verticalSpacing;

			for (int i = 0; i < rowsCount; i++)
			{
				int cardsInRow = (int)Mathf.Clamp(cardsLeft, 0f, columnsCount);
				float currentRowPosition = firstRowPosition - _verticalSpacing * i;
				cardsArrangementList.AddRange(CalculateRowArrangement(currentRowPosition, cardsInRow));
				cardsLeft -= cardsInRow;
			}

			return cardsArrangementList;
		}

		private List<Vector3> CalculateRowArrangement(float currentRowPosition, int cardsInRow)
		{
			List<Vector3> cardsInRowArrangement = new();
			float firstCardPosition = _horizontalSpacing / 2f * (cardsInRow + 1) - _horizontalSpacing;
			for (int i = 0; i < cardsInRow; i++)
			{
				float currentColumnCardPosition = firstCardPosition - _horizontalSpacing * i;
				Vector3 cardPosition = new Vector3(currentColumnCardPosition, 0f, currentRowPosition);
				cardsInRowArrangement.Add(cardPosition);
			}

			return cardsInRowArrangement;
		}
	}
}