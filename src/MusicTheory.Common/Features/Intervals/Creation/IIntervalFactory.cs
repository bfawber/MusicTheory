namespace MusicTheory.Common.Features.Intervals.Creation;

/// <summary>
/// For creating intervals.
/// </summary>
public interface IIntervalFactory
{
	/// <summary>
	/// Create an inteval by its short name.
	/// </summary>
	/// <param name="shortName">The short name of the interval.</param>
	/// <returns>The associated interval.</returns>
	IInterval Create(string shortName);

	/// <summary>
	/// Creates a random interval.
	/// </summary>
	/// <returns>An new random interval.</returns>
	IInterval CreateRandom();
}
