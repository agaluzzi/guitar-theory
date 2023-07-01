namespace GuitarTheory;

public class FretboardOverlay
{
    public event Action? Changed;
    private void PublishChange() => Changed?.Invoke();

    public IEnumerable<Tone> Tones => pattern?.GetTones(root) ?? Enumerable.Empty<Tone>();

    public Note Root
    {
        get => root;
        set
        {
            root = value;
            PublishChange();
        }
    }

    public IPattern? Pattern
    {
        get => pattern;
        set
        {
            pattern = value;
            PublishChange();
        }
    }

    private Note root = Note.C;
    private IPattern? pattern = Scales.All[0];
}