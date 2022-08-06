namespace MusicTheory.Common.Features.Intervals;

public class MinorSixth : IInterval
{
	public int NumberOfSteps => 5;

	public ModificationKind Modification => ModificationKind.Minor;

	public string Name => "Minor Sixth";

	public string ShortName => "m6";
}
