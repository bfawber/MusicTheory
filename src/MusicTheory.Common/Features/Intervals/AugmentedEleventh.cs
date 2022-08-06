namespace MusicTheory.Common.Features.Intervals;

public class AugmentedEleventh : IInterval
{
	public int NumberOfSteps => 10;

	public ModificationKind Modification => ModificationKind.Augmented;

	public string Name => "Augmented Eleventh";

	public string ShortName => "+11";
}
