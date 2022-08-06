namespace MusicTheory.Common.Features.Intervals;

public class MajorSixth : IInterval
{
	public int NumberOfSteps => 5;

	public ModificationKind Modification => ModificationKind.Major;

	public string Name => "Major Sixth";

	public string ShortName => "6";
}
