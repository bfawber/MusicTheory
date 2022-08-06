namespace MusicTheory.Common.Features.Intervals;

public interface IInterval
{
	int NumberOfSteps { get; }

	ModificationKind Modification { get; }

	string Name { get; }

	string ShortName { get; }
}
