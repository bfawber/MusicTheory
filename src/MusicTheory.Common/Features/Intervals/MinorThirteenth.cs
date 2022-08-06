namespace MusicTheory.Common.Features.Intervals;

public class MinorThirteenth : IInterval
{
	public int NumberOfSteps => 12;

	public ModificationKind Modification => ModificationKind.Minor;

	public string Name => "Minor Thirteenth";

	public string ShortName => "m13";
}
