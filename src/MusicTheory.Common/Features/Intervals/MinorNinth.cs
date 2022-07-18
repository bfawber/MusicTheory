namespace MusicTheory.Common.Features.Intervals;

public class MinorNinth : IInterval
{
	public int NumberOfSteps => 9;

	public ModificationKind Modification => ModificationKind.Minor;
}
