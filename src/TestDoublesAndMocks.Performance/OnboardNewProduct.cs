using BenchmarkDotNet.Attributes;
using TestDoublesAndMocks.Tests;

namespace TestDoublesAndMocks.Performance;

[MemoryDiagnoser]
public class OnboardNewProduct
{
	[Benchmark]
	public void OnboardNewProductUsingRocks() => 
		ProductServiceTests.OnboardNewProductUsingRocks();

	[Benchmark]
	public void OnboardNewProductUsingNSubstitute() =>
		ProductServiceTests.OnboardNewProductUsingNSubstitute();

	[Benchmark]
	public void OnboardNewProductUsingTestDouble() =>
		ProductServiceTests.OnboardNewProductUsingTestDouble();

	[Benchmark(Baseline = true)]
   public void OnboardNewProductUsingTestDoubleAndFluentInterfaces() => 
		ProductServiceTests.OnboardNewProductUsingTestDoubleAndFluentInterfaces();
}