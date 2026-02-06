using StudyProject.ScriptableObjects.TradingSystemData;
using StudyProject.UI.TradingSystem;
using UnityEngine;

namespace StudyProject.TradingSystem
{
	public class TradingSystemController : MonoBehaviour
	{
		[SerializeField]
		private TradingSystemPanel _tradingSystemPanel;
		
		[Header("Data")]
		[SerializeField]
		private ProductDataAsset _productDataAsset;

		private ProductController _product;

		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			InitializeProducts();
			RecalculateDay();
			_tradingSystemPanel.RecalculateEvent += RecalculateDay;
		}

		private void InitializeProducts()
		{
			var product = new BreadProductController();
			product.Initialize(GetProductData(_productDataAsset));
			_product = product;
		}

		private ProductData GetProductData(ProductDataAsset productDataAsset)
		{
			return new ProductData()
			{
				Icon = productDataAsset.Icon,
				Name = productDataAsset.Name,
				Needs = productDataAsset.Needs,
				Production = productDataAsset.Production,
				Import = productDataAsset.Import,
				BasicPrice = productDataAsset.BasicPrice,
			};
		}

		private void RecalculateDay()
		{
			CalculateDay();
			_tradingSystemPanel.Initialize(_product.ProductData, _product.ProductsInStock, _product.AdditionalNeeds);
		}
		
		private void CalculateDay()
		{
			_product.RecalculateNeeds();
		}
	}
}