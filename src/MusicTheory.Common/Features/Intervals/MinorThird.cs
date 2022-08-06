namespace MusicTheory.Common.Features.Intervals;

public class MinorThird : IInterval
{
	public int NumberOfSteps => 2;

	public ModificationKind Modification => ModificationKind.Minor;

	public string Name => "Minor Third";

	public string ShortName => "m3";
}
