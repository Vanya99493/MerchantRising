using System;
using System.Collections.Generic;
using StudyProject.TradingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.TradingSystem
{
	public class TradingSystemPanel : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _productInStockText;

		[SerializeField]
		private TMP_Text _additionalNeedsText;
		
		[SerializeField]
		private Button _recalculateButton;

		[SerializeField]
		private ProductElementsFactory _productElementsFactory;

		private List<ProductElement> _activeProductElements = new();

		public event Action RecalculateEvent;

		private void OnEnable()
		{
			_recalculateButton.onClick.AddListener(OnRecalculateButtonClickEventHandler);
		}

		private void OnDestroy()
		{
			_recalculateButton.onClick.RemoveListener(OnRecalculateButtonClickEventHandler);
		}

		public void Initialize(ProductData productData, int productInStock, int additionalNeeds)
		{
			ClearActiveProductElements();
			CreateProductElement(productData);

			_productInStockText.text = $"Товару на складі: {productInStock}";
			_additionalNeedsText.text = $"Додаткові потреби: {additionalNeeds}";
		}

		private void CreateProductElement(ProductData productData)
		{
			var productElement = _productElementsFactory.InstantiateProductElement(productData);
			_activeProductElements.Add(productElement);
		}

		private void ClearActiveProductElements()
		{
			foreach (var activeProductElement in _activeProductElements)
			{
				activeProductElement.Destroy();
			}
			_activeProductElements.Clear();
		}

		private void OnRecalculateButtonClickEventHandler()
		{
			RecalculateEvent?.Invoke();
		}
	}
}