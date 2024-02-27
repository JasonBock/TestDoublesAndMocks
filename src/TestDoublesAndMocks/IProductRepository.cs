namespace TestDoublesAndMocks;

public interface IProductRepository
{
	void Store(Product product);
	Product Get(int id);
}