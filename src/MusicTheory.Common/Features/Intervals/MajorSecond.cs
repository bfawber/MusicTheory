namespace MusicTheory.Common.Features.Intervals;

public class MajorSecond : IInterval
{
	public int NumberOfSteps => 1;

	public ModificationKind Modification => ModificationKind.None;
}
