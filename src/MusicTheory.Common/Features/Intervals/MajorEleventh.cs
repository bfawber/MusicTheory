namespace MusicTheory.Common.Features.Intervals;

public class MajorEleventh : IInterval
{
	public int NumberOfSteps => 10;

	public ModificationKind Modification => ModificationKind.Major;

	public string Name => "Major Eleventh";

	public string ShortName => "11";
}
