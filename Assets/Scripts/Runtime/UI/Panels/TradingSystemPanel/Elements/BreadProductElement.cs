using StudyProject.TradingSystem;
using TMPro;
using UnityEngine;

namespace StudyProject.UI.TradingSystem
{
	public class BreadProductElement : ProductElement
	{
		[SerializeField]
		private TMP_Text _adjustedPriceText;

		public override void Initialize(ProductData productData)
		{
			base.Initialize(productData);

			var breadProductData = productData as BreadProductData;
			_adjustedPriceText.text = $"Скоригована ціна: {breadProductData.AdjustedPrice}";
		}
	}
}