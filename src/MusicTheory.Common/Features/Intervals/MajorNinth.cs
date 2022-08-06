namespace MusicTheory.Common.Features.Intervals;

public class MajorNinth : IInterval
{
	public int NumberOfSteps => 8;

	public ModificationKind Modification => ModificationKind.Major;

	public string Name => "Major Ninth";

	public string ShortName => "9";
}
