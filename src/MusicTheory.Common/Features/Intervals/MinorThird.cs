namespace MusicTheory.Common.Features.Intervals;

public class MinorThird : IInterval
{
	public int NumberOfSteps => 2;

	public ModificationKind Modification => ModificationKind.Minor;
}
