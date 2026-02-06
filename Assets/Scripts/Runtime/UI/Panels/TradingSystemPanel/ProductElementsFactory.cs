using StudyProject.TradingSystem;
using UnityEngine;

namespace StudyProject.UI.TradingSystem
{
	public class ProductElementsFactory : MonoBehaviour
	{
		[SerializeField]
		private BreadProductElement _breadProductElementPrefab;

		[SerializeField]
		private Transform _productElementsParent;
		
		public ProductElement InstantiateProductElement(ProductData productData)
		{
			switch (productData)
			{
				case BreadProductData:
					var productElement = Instantiate(_breadProductElementPrefab, _productElementsParent);
					productElement.Initialize(productData);
					productElement.DestroyEvent += OnProductElementDestroyEventHandler;
					return productElement;
				default:
					return null;
			}
		}

		private void OnProductElementDestroyEventHandler(ProductElement productElement)
		{
			Destroy(productElement.gameObject);
		}
	}
}