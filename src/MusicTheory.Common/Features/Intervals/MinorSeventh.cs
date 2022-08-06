namespace MusicTheory.Common.Features.Intervals;

public class MinorSeventh : IInterval
{
	public int NumberOfSteps => 6;

	public ModificationKind Modification => ModificationKind.Minor;

	public string Name => "Minor Seventh";

	public string ShortName => "m7";
}
