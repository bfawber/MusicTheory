namespace MusicTheory.Common.Features.Intervals;

public class MinorNinth : IInterval
{
	public int NumberOfSteps => 8;

	public ModificationKind Modification => ModificationKind.Minor;
}
