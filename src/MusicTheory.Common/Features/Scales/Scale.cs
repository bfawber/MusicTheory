using MusicTheory.Common.Core.DataStructures;
using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Scales;

public class Scale
{
	public string Name { get; init; }

	public Linked<Note> Notes { get; init; } = new Linked<Note>();
}
