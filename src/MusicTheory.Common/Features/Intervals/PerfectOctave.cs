namespace MusicTheory.Common.Features.Intervals;

public class PerfectOctave : IInterval
{
	public int NumberOfSteps => 7;

	public ModificationKind Modification => ModificationKind.None;
}
