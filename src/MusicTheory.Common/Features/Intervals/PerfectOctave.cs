namespace MusicTheory.Common.Features.Intervals;

public class PerfectOctave : IInterval
{
	public int NumberOfSteps => 8;

	public ModificationKind Modification => ModificationKind.None;
}
