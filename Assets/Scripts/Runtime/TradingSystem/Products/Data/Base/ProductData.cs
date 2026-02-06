using System;
using UnityEngine;

namespace StudyProject.TradingSystem
{
	[Serializable]
	public class ProductData
	{
		public Sprite Icon;
		public string Name;
		
		public int Needs;
		public int Production;
		public int Import;
		public int BasicPrice;
	}
}