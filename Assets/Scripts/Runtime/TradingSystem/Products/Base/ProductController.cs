namespace StudyProject.TradingSystem
{
	public abstract class ProductController
	{
		public abstract ProductData ProductData { get; }
		public abstract int ProductsInStock { get; }
		public abstract int AdditionalNeeds { get; }

		public abstract void Initialize(ProductData productData);

		public abstract void RecalculateNeeds();
	}
}