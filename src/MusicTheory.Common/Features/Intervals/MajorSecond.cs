namespace MusicTheory.Common.Features.Intervals;

public class MajorSecond : IInterval
{
	public int NumberOfSteps => 1;

	public ModificationKind Modification => ModificationKind.Major;

	public string Name => "Major Second";

	public string ShortName => "2";
}
