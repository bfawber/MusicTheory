using MusicTheory.Common.Core.Extensions;

namespace MusicTheory.Common.Features.Intervals.Creation;

/// <inheritdoc/>
public class IntervalFactory : IIntervalFactory
{
	private readonly Dictionary<string, IInterval> _intervals = new Dictionary<string, IInterval>();
	private readonly Random _random = new Random();

	public IntervalFactory()
	{
		var type = typeof(IInterval);
		var types = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(s => s.GetTypes())
			.Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

		foreach (var intervalType in types)
		{
			var interval = (IInterval)Activator.CreateInstance(intervalType);
			_intervals.Add(interval.ShortName, interval);
		}
	}

	/// <inheritdoc/>
	public IInterval Create(string shortName)
	{
		if (shortName.IsNullEmptyOrWhitespace())
		{
			throw new ArgumentException(nameof(shortName));
		}

		if (!_intervals.TryGetValue(shortName, out IInterval interval))
		{
			throw new ArgumentOutOfRangeException($"Invalid interval type '{shortName}'");
		}

		return interval;
	}

	/// <inheritdoc/>
	public IInterval CreateRandom()
	{
		int i = _random.Next(0, _intervals.Count - 1);
		return _intervals.ElementAt(i).Value;
	}
}
