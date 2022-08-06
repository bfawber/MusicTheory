namespace MusicTheory.Common.Features.Intervals;

public class MajorThirtheenth : IInterval
{
	public int NumberOfSteps => 12;

	public ModificationKind Modification => ModificationKind.Major;

	public string Name => "Major Thirteenth";

	public string ShortName => "13";
}
