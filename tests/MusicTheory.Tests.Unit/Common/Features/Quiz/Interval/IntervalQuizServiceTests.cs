using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Intervals.Creation;
using MusicTheory.Common.Features.Notes.Creation;
using MusicTheory.Common.Features.Quiz.Interval;
using MusicTheory.Common.Features.Scales;
using System;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Features.Quiz.Interval;

public class IntervalQuizServiceTests
{
	private readonly IAccidentalsService _accidentalsService = new AccidentalsService();

	[Fact]
	public void Ctor_WithInvalidOptions_ThrowsException()
	{
		Assert.Throws<ArgumentException>(() => Create(new IntervalQuizServiceOptions(false, false)));
	}

	[Fact]
	public void GetQuestion_WithOnlyAbove_CreatesAboveQuestions()
	{
		var quizService = Create(new IntervalQuizServiceOptions(true, false));

		var question = quizService.GetQuestion();
		Assert.NotNull(question);

		var intervalService = new IntervalService(new MajorScaleBuilder(new StepService(_accidentalsService)), _accidentalsService);
		var answer = intervalService.GetAbove(question.StartingNote, question.Interval);

		Assert.Equal(answer, question.Answer);
	}

	[Fact]
	public void GetQuestion_WithOnlyBelow_CreatesBelowQuestions()
	{
		var quizService = Create(new IntervalQuizServiceOptions(false, true));

		var question = quizService.GetQuestion();
		Assert.NotNull(question);

		var intervalService = new IntervalService(new MajorScaleBuilder(new StepService(_accidentalsService)), _accidentalsService);
		var answer = intervalService.GetBelow(question.StartingNote, question.Interval);

		Assert.Equal(answer, question.Answer);
	}

	private IntervalQuizService Create(IntervalQuizServiceOptions options) => new IntervalQuizService(options, new NoteFactory(_accidentalsService), new IntervalFactory(), new IntervalService(new MajorScaleBuilder(new StepService(_accidentalsService)), _accidentalsService));
}
