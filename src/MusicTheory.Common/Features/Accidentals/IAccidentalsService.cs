namespace MusicTheory.Common.Features.Accidentals;

public interface IAccidentalsService
{
	string GetAccidental(string note);

	string RaiseAccidental(string accidental);

	string LowerAccidental(string accidental);
}
