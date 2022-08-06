namespace MusicTheory.Common.Features.Intervals;

public class MajorSeventh : IInterval
{
	public int NumberOfSteps => 6;

	public ModificationKind Modification => ModificationKind.Major;

	public string Name => "Major Seventh";

	public string ShortName => "7";
}
