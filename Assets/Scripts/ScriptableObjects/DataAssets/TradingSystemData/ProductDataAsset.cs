using UnityEngine;

namespace StudyProject.ScriptableObjects.TradingSystemData
{
	[CreateAssetMenu(fileName = "ProductDataAsset", menuName = "Scriptable Objects/Data Assets/Trading System/Product Data Asset")]
	public class ProductDataAsset : ScriptableObject
	{
		[field: SerializeField]
		public Sprite Icon { get; private set; }
		
		[field: SerializeField]
		public string Name { get; private set; }
		
		[field: SerializeField]
		public int Needs { get; private set; }
		
		[field: SerializeField]
		public int Production { get; private set; }
		
		[field: SerializeField]
		public int Import { get; private set; }
		
		[field: SerializeField]
		public int BasicPrice { get; private set; }
		
		[field: SerializeField]
		public int AdjustedPrice { get; private set; }
	}
}