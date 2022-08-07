namespace MusicTheory.Common.Features.Quiz.Interval;

/// <summary>
/// For creating interval quiz questions.
/// </summary>
public interface IIntervalQuizService
{
	/// <summary>
	/// Get's a new quiz question.
	/// </summary>
	/// <param name="options">The options that can be used to create the question.</param>
	/// <returns>A quiz question as a <see cref="IntervalQuizQuestion"/>.</returns>
	IntervalQuizQuestion GetQuestion(IntervalQuizQuestionOptions options);
}
