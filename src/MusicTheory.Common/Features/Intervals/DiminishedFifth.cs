namespace MusicTheory.Common.Features.Intervals;

public class DiminishedFifth : IInterval
{
	public int NumberOfSteps => 4;

	public ModificationKind Modification => ModificationKind.Diminished;

	public string Name => "Diminished Fifth";

	public string ShortName => "-5";
}
