using System;
using StudyProject.TradingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI.TradingSystem
{
	public class ProductElement : MonoBehaviour, IDestroyableElement<ProductElement>
	{
		[SerializeField]
		private Image _productImage;

		[SerializeField]
		private TMP_Text _nameText;
		
		[SerializeField] 
		private TMP_Text _needsText;
		
		[SerializeField]
		private TMP_Text _productionText;
		
		[SerializeField]
		private TMP_Text _importText;
		
		[SerializeField]
		private TMP_Text _basicPriceText;
		
		public event Action<ProductElement> DestroyEvent;

		public virtual void Initialize(ProductData productData)
		{
			_productImage.sprite = productData.Icon;
			_nameText.text = productData.Name;
			_needsText.text = $"Потреба: {productData.Needs}";
			_productionText.text = $"Виготовлення: {productData.Production}";
			_importText.text = $"Імпорт: {productData.Import}";
			_basicPriceText.text = $"Початкова ціна: {productData.BasicPrice}";
		}
		
		public void Destroy()
		{
			DestroyEvent?.Invoke(this);
		}
	}
}