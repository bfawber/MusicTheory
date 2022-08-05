namespace MusicTheory.Common.Features.Notes;

public class Note : IEquatable<Note>
{
	public string Name { get; init; }
	public string Accidental { get; init; }

	public override bool Equals(object obj)
	{
		return Equals(obj as Note);
	}

	public bool Equals(Note other)
	{
		return other != null &&
			   Name == other.Name &&
			   Accidental == other.Accidental;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Name, Accidental);
	}

	public static bool operator ==(Note left, Note right)
	{
		return Equals(left, right);
	}

	public static bool operator !=(Note left, Note right)
	{
		return !(left == right);
	}
}
