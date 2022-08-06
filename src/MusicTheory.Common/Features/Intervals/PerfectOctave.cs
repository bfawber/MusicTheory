namespace MusicTheory.Common.Features.Intervals;

public class PerfectOctave : IInterval
{
	public int NumberOfSteps => 7;

	public ModificationKind Modification => ModificationKind.Perfect;

	public string Name => "Perfect Octave";

	public string ShortName => "8";
}
