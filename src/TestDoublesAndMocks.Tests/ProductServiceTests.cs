using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Rocks;

namespace TestDoublesAndMocks.Tests;

[RockCreate<IProductRepository>]
public static class ProductServiceTests
{
	[Test]
	public static void OnboardNewProductUsingRocks()
	{
		var expectations = new IProductRepositoryCreateExpectations();
		expectations.Methods.Store(Rocks.Arg.Validate<Product>(product => product.Id == 123));

		var service = new ProductService(expectations.Instance());
		service.OnboardNewProduct(123, "Product 123");

		expectations.Verify();
	}

	[Test]
	public static void OnboardNewProductUsingNSubstitute()
	{
		var repository = Substitute.For<IProductRepository>();
		var service = new ProductService(repository);

		service.OnboardNewProduct(123, "Product 123");

		repository.Received().Store(NSubstitute.Arg.Is<Product>(p => p.Id == 123));
	}

	[Test]
	public static void OnboardNewProductUsingTestDouble()
	{
		var repository = new InMemoryProductRepository();

		var service = new ProductService(repository);
		service.OnboardNewProduct(123, "Product 123");

		Assert.That(repository.DidStore(123), Is.True);
	}

	[Test]
	public static void OnboardNewProductUsingTestDoubleAndFluentInterfaces()
	{
		var repository = new InMemoryProductRepository();

		var service = new ProductService(repository);
		service.OnboardNewProduct(123, "Product 123");

		repository.DidStore(123).Should().BeTrue();
	}

	[Test]
	public static void CouldNotStoreProductUsingRocks()
	{
		var expectations = new IProductRepositoryCreateExpectations();
		expectations.Methods.Store(Rocks.Arg.Any<Product>()).Callback(_ => throw new InvalidOperationException("oh no!"));

		var service = new ProductService(expectations.Instance());

		Assert.That(() => service.OnboardNewProduct(123, "Product 123"),
			Throws.TypeOf<InvalidOperationException>().With.Message.EqualTo("oh no!"));

		expectations.Verify();
	}

	[Test]
	public static void CouldNotStoreProductUsingTestDoubleAndFluentInterfaces()
	{
		var repository = new InMemoryProductRepository()
			.AlwaysThrowsWhenStoring(new InvalidOperationException("oh no!"));

		var service = new ProductService(repository);

		var onboardNewProduct = () => service.OnboardNewProduct(123, "Product 123");
		onboardNewProduct.Should().ThrowExactly<InvalidOperationException>()
		  .WithMessage("oh no!");
	}
}