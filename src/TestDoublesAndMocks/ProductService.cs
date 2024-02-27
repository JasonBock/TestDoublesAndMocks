namespace TestDoublesAndMocks;

public class ProductService(IProductRepository _productRepository)
{
	public void OnboardNewProduct(int id, string name) =>
		_productRepository.Store(new Product(id, name));
}