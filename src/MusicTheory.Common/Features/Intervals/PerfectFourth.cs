namespace MusicTheory.Common.Features.Intervals;

public class PerfectFourth : IInterval
{
	public int NumberOfSteps => 3;

	public ModificationKind Modification => ModificationKind.Perfect;

	public string Name => "Perfect Fourth";

	public string ShortName => "4";
}
