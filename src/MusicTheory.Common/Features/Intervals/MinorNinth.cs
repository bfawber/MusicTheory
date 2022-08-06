namespace MusicTheory.Common.Features.Intervals;

public class MinorNinth : IInterval
{
	public int NumberOfSteps => 8;

	public ModificationKind Modification => ModificationKind.Minor;

	public string Name => "Minor Ninth";

	public string ShortName => "m9";
}
