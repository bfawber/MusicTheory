using MusicTheory.Common.Core.Extensions;
using MusicTheory.Common.Core.Services;

namespace MusicTheory.Common.Features.Intervals.Creation;

/// <inheritdoc/>
public class IntervalFactory : IIntervalFactory
{
	private readonly Dictionary<string, IInterval> _intervals = new Dictionary<string, IInterval>();
	private readonly IRandomService _randomService;

	public IntervalFactory(IRandomService randomService)
	{
		_randomService = randomService ?? throw new ArgumentNullException(nameof(randomService));
		
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
			throw new ArgumentException("Interval short name cannot be null, empty, or whitespace.", nameof(shortName));
		}

		if (!_intervals.TryGetValue(shortName, out IInterval interval))
		{
			throw new ArgumentOutOfRangeException(nameof(shortName), $"Invalid interval type '{shortName}'. Valid interval types are: {string.Join(", ", _intervals.Keys)}");
		}

		return interval;
	}

	/// <inheritdoc/>
	public IInterval CreateRandom()
	{
		int i = _randomService.Next(0, _intervals.Count - 1);
		return _intervals.ElementAt(i).Value;
	}
}
