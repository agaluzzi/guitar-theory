namespace GuitarTheory;

public partial class GuitarView
{
    private RectF FretboardBounds { get; set; }
    private float FretSpacing { get; set; }
    private float FretWidth { get; set; }
    private float NutWidth { get; set; }
    private float InlayRadius { get; set; }
    private float StringInset { get; set; }
    private float StringSpacing { get; set; }

    private float NoteRadius { get; set; }
    private float NoteTextSize { get; set; }
    private float DegreeTextSize { get; set; }
    private float ArrowHeight { get; set; }
    private float ArrowWidth { get; set; }

    private void ComputeSizes(RectF bounds)
    {
        FretSpacing = bounds.Width / FretCount;
        FretWidth = FretSpacing / 12;
        NutWidth = FretWidth * 1.5f;

        var fretboardHeight = FretSpacing * StringCount * 0.5f;
        StringInset = fretboardHeight * 0.03f;
        StringSpacing = (fretboardHeight - (2 * StringInset)) / (StringCount - 1);
        NoteRadius = StringSpacing * 0.35f;

        var fretboardOffsetX = FretSpacing;
        var fretboardWidth = bounds.Width - fretboardOffsetX;
        var fretboardOffsetY = (bounds.Height - fretboardHeight) / 2;

        FretboardBounds = new RectF(
            x: bounds.X + fretboardOffsetX,
            y: bounds.Y + fretboardOffsetY,
            width: fretboardWidth,
            height: fretboardHeight);

        NoteTextSize = NoteRadius * 0.8f;
        DegreeTextSize = NoteRadius * 0.5f;

        ArrowWidth = NoteRadius * 0.5f;
        ArrowHeight = ArrowWidth * 1.5f;

        InlayRadius = StringSpacing * 0.3f;
    }
}