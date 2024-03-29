﻿namespace MusicTheory.Common.Features.Intervals;

public class MinorSecond : IInterval
{
	public int NumberOfSteps => 1;

	public ModificationKind Modification => ModificationKind.Minor;

	public string Name => "Minor Second";

	public string ShortName => "m2";
}
