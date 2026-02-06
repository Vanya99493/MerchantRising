
using UnityEngine;

namespace StudyProject.TradingSystem
{
	public class BreadProductController : ProductController
	{
		private ProductData _basicProductData;
		private BreadProductData _adjustedProductData;

		public override ProductData ProductData => _adjustedProductData;

		private int _productsInStock;
		private int _additionalNeeds;

		public override int ProductsInStock => _productsInStock;
		public override int AdditionalNeeds => _additionalNeeds;
		
		public override void Initialize(ProductData productData)
		{
			_basicProductData = productData;
			
			_adjustedProductData = new BreadProductData()
			{
				Icon = _basicProductData.Icon,
				Name = _basicProductData.Name,
				Needs = _basicProductData.Needs,
				Production = _basicProductData.Production,
				Import = _basicProductData.Import,
				BasicPrice = _basicProductData.BasicPrice,
				AdjustedPrice = 0,
			};
		}

		public override void RecalculateNeeds()
		{
			RecalculateNeedsParameter();
			RecalculateProductionParameters();
			RecalculateImportParameter();
			AdjustPrice();
		}

		private void RecalculateNeedsParameter()
		{
			_adjustedProductData.Needs = Mathf.RoundToInt(_basicProductData.Needs * 0.8f + Random.Range(0f, 0.4f) * _basicProductData.Needs);
		}

		private void RecalculateProductionParameters()
		{
			_adjustedProductData.Production = Mathf.RoundToInt(_basicProductData.Production * 0.8f + Random.Range(0f, 0.2f) * _basicProductData.Production);
		}

		private void RecalculateImportParameter()
		{
			_adjustedProductData.Import = Mathf.RoundToInt(_basicProductData.Import * 0.5f + Random.Range(0f, 0.5f) * _basicProductData.Import);
		}

		private void AdjustPrice()
		{
			var availableProducts = _adjustedProductData.Production + _adjustedProductData.Import;
			var productLeft = availableProducts - _adjustedProductData.Needs;

			// TODO: add additional needs cover
			if (productLeft >= 0)
			{
				_productsInStock = Mathf.Clamp(_productsInStock + productLeft, 0, _basicProductData.Needs);
				
				var adjustedPrice = Mathf.RoundToInt(_adjustedProductData.BasicPrice * (1f - _productsInStock * 1f / _adjustedProductData.Needs));
				_adjustedProductData.AdjustedPrice = Mathf.Clamp(adjustedPrice, Mathf.RoundToInt(_adjustedProductData.BasicPrice * 0.5f), _adjustedProductData.BasicPrice);
			}
			else if(_productsInStock >= -productLeft)
			{
				_productsInStock -= -productLeft;
				
				var adjustedPrice = Mathf.RoundToInt(_adjustedProductData.BasicPrice * (1f - _productsInStock * 1f / _adjustedProductData.Needs));
				_adjustedProductData.AdjustedPrice = Mathf.Clamp(adjustedPrice, Mathf.RoundToInt(_adjustedProductData.BasicPrice * 0.5f), _adjustedProductData.BasicPrice);
			}
			else
			{
				if (_productsInStock > 0)
				{
					productLeft += _productsInStock;
					_productsInStock = 0;
				}

				_additionalNeeds += -productLeft;

				var adjustedPrice = Mathf.RoundToInt(_adjustedProductData.BasicPrice + _adjustedProductData.BasicPrice * (_additionalNeeds * 1f / _adjustedProductData.Needs));
				_adjustedProductData.AdjustedPrice = Mathf.Clamp(adjustedPrice, _adjustedProductData.BasicPrice, _adjustedProductData.BasicPrice * 2);
			}
		}
	}
}