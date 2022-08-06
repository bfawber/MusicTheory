namespace MusicTheory.Common.Features.Intervals;

public class AugmentedFourth : IInterval
{
	public int NumberOfSteps => 3;

	public ModificationKind Modification => ModificationKind.Augmented;

	public string Name => "Augmented Fourth";

	public string ShortName => "+4";
}
