namespace MusicTheory.Common.Features.Intervals;

public class AugmentedFifth : IInterval
{
	public int NumberOfSteps => 4;

	public ModificationKind Modification => ModificationKind.Augmented;

	public string Name => "Augmented Fifth";

	public string ShortName => "+5";
}
