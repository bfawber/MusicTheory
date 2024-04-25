namespace MusicTheory.Common.Features.Scales.ScaleDegree;

public class ScaleDegree
{
	public int Degree { get; init; }

	public IOrderedEnumerable<ScaleDegree> Resolutions { get; init; }

	public int TensionRank { get; init; }
}
