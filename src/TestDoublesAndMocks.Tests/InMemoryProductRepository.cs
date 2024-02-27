namespace TestDoublesAndMocks.Tests;

public class InMemoryProductRepository 
	: IProductRepository
{
	private readonly List<Product> products = new();
	private Exception? alwaysThrowsWhenStoring;

	public void Store(Product product)
	{
		if (this.alwaysThrowsWhenStoring is not null)
		{
			throw this.alwaysThrowsWhenStoring;
		}

		this.products.Add(product);
	}

	/// <remarks>
	/// The original implementation did "FirstOrDefault()", but that could return null.
	/// But you can't make the return type "Product?", because that isn't what the interface
	/// specified. So, I changed the call to "First()".
	/// </remarks>
	public Product Get(int id) => this.products.First(p => p.Id == id);

	public InMemoryProductRepository AlwaysThrowsWhenStoring(Exception e)
	{
		this.alwaysThrowsWhenStoring = e;
		return this;
	}

	public bool DidStore(int id) => this.Get(id) is not null;
}