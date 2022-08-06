namespace MusicTheory.Common.Features.Intervals;

public class PerfectFifth : IInterval
{
	public int NumberOfSteps => 4;

	public ModificationKind Modification => ModificationKind.Perfect;

	public string Name => "Perfect Fifth";

	public string ShortName => "5";
}
