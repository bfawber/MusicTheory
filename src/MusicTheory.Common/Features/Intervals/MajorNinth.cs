namespace MusicTheory.Common.Features.Intervals;

public class MajorNinth : IInterval
{
	public int NumberOfSteps => 8;

	public ModificationKind Modification => ModificationKind.Major;
}
