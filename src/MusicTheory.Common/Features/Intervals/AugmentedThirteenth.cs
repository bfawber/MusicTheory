﻿namespace MusicTheory.Common.Features.Intervals;

public class AugmentedThirteenth : IInterval
{
	public int NumberOfSteps => 13;

	public ModificationKind Modification => ModificationKind.Augmented;

	public string Name => "Augmented Thirteenth";

	public string ShortName => "+13";
}
