namespace MusicTheory.Common.Features.Intervals;

public class MajorThird : IInterval
{
	public int NumberOfSteps => 2;

	public ModificationKind Modification => ModificationKind.Major;

	public string Name => "Major Third";

	public string ShortName => "3";
}
