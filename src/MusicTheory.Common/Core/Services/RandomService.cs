namespace MusicTheory.Common.Core.Services;

/// <summary>
/// Thread-safe random number generator service.
/// </summary>
public class RandomService : IRandomService
{
	private readonly Random _random;

	public RandomService()
	{
		_random = new Random();
	}

	/// <inheritdoc />
	public int Next()
	{
		lock (_random)
		{
			return _random.Next();
		}
	}

	/// <inheritdoc />
	public int Next(int maxValue)
	{
		lock (_random)
		{
			return _random.Next(maxValue);
		}
	}

	/// <inheritdoc />
	public int Next(int minValue, int maxValue)
	{
		lock (_random)
		{
			return _random.Next(minValue, maxValue);
		}
	}
}