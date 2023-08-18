using GuitarTheory.Extensions;
using GuitarTheory.UI.Support;

namespace GuitarTheory;

public class ChromaticPanel : XGraphicsView
{
    private readonly Thickness padding = new(horizontalSize: 20, verticalSize: 0);

    private readonly FretboardOverlay overlay;
    private readonly TouchMap<Note> touchMap = new();

    public ChromaticPanel(FretboardOverlay overlay)
    {
        this.overlay = overlay;
        overlay.Changed += Invalidate;
        StartInteraction += OnStartInteraction;
    }

    protected override void Draw(
        ICanvas canvas,
        float top,
        float bottom,
        float left,
        float right,
        float width,
        float height,
        PointF center,
        RectF bounds)
    {
        // Determine sizing/positioning, based on the available width
        var noteSpacing = (float) (width - padding.HorizontalThickness) / 12;
        var panelHeight = noteSpacing * 1.25f;
        var panelBounds = bounds with {Height = panelHeight, Top = center.Y - (panelHeight / 2)};

        // Background
        canvas.FillRectangle(panelBounds, Colors.LightGray.AsPaint());

        // Notes
        var tones = overlay.Tones.ToArray();
        touchMap.Clear();
        for (var i = 0; i < 12; i++)
        {
            var pitch = overlay.Root.Pitch + i;
            var tone = tones.FirstOrDefault(t => t.Matches(pitch));
            var note = tone?.Note ?? Note.Get(pitch);

            var noteBounds = new RectF(
                x: left + (float) padding.Left + (i * noteSpacing),
                y: panelBounds.Top,
                width: noteSpacing,
                height: panelHeight);

            DrawNote(note, tone?.Interval, noteBounds, canvas);

            touchMap.Add(noteBounds, note);
        }
    }

    private void DrawNote(Note note, Interval? interval, RectF bounds, ICanvas canvas)
    {
        var options = interval == null ?
            NoteOptions.GrayedOut :
            interval.IsRoot ?
                NoteOptions.Emphasized :
                NoteOptions.None;

        // Colored circle with note name (translucent if it's not included in the current pattern)
        DrawingUtils.DrawNote(note,
            interval,
            center: bounds.Center.Offset(dx: 0, dy: bounds.Height * -0.1f),
            radius: bounds.Width * .3f,
            canvas,
            options);

        // Interval label, below the circle
        if (interval != null)
        {
            var label = interval.IsRoot ? "Root" : interval.Abbreviation;
            canvas.DrawString(label,
                RectF.FromLTRB(
                    left: bounds.Left,
                    top: bounds.Top + (bounds.Height * .7f),
                    right: bounds.Right,
                    bottom: bounds.Bottom),
                size: bounds.Width * 0.2f,
                Colors.Black,
                vertical: VerticalAlignment.Top);
        }
    }

    private void OnStartInteraction(object? _, TouchEventArgs e)
    {
        foreach (var touch in e.Touches)
        {
            var note = touchMap.GetValueAt(touch);
            if (note != null)
            {
                if (note == overlay.Root)
                {
                    note = note.GetAlternate();
                }
                overlay.Root = note;
                return;
            }
        }
    }
}