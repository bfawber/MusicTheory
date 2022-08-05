namespace MusicTheory.Common.Features.Intervals;

public class PerfectUnison : IInterval
{
    public int NumberOfSteps => 0;

    public ModificationKind Modification => ModificationKind.Perfect;
}
