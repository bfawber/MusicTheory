namespace MusicTheory.Common.Features.Intervals;

public class DiminishedSeventh : IInterval
{
	public int NumberOfSteps => 6;

	public ModificationKind Modification => ModificationKind.Diminished;

	public string Name => "Diminished Seventh";

	public string ShortName => "-7";
}
