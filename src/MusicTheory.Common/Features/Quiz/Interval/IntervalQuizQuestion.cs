using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Quiz.Interval;

public record IntervalQuizQuestion(
	Note StartingNote,
	IInterval Interval,
	Note Answer
);
