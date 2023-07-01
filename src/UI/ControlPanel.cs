using GuitarTheory.Extensions;
using GuitarTheory.UI.Support;

namespace GuitarTheory;

public class ControlPanel : XGraphicsView
{
    private readonly FretboardOverlay overlay;
    private readonly TouchMap<Note> touchMap = new();

    public ControlPanel(FretboardOverlay overlay)
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
        var noteSpacing = width / 12;
        var panelHeight = noteSpacing * 1.5f;
        var panelBounds = bounds with {Height = panelHeight, Top = center.Y - (panelHeight / 2)};

        // Background
        canvas.FillRectangle(panelBounds, Colors.LightGray.AsPaint());

        // Title
        canvas.DrawString(
            value: overlay.Title,
            bounds: bounds with {Bottom = panelBounds.Top},
            size: noteSpacing * 0.3f,
            color: Colors.White,
            weight: FontWeights.ExtraBold,
            vertical: VerticalAlignment.Bottom);

        // Notes
        var tones = overlay.Tones.ToArray();
        touchMap.Clear();
        for (var i = 0; i < 12; i++)
        {
            var pitch = overlay.Root.Pitch + i;
            var tone = tones.FirstOrDefault(t => t.Matches(pitch));
            var note = tone?.Note ?? Note.Get(pitch);

            var noteBounds = new RectF(
                x: left + (i * noteSpacing),
                y: panelBounds.Top,
                width: noteSpacing,
                height: panelHeight);

            DrawNote(note, tone?.Interval, noteBounds, canvas);

            touchMap.Add(noteBounds, note);
        }
    }

    private void DrawNote(Note note, Interval? interval, RectF bounds, ICanvas canvas)
    {
        // Colored circle with note name (translucent if it's not included in the current pattern)
        canvas.Alpha = interval == null ? 0.2f : 1.0f;
        DrawingUtils.DrawNote(note,
            center: bounds.Center.Offset(dx: 0, dy: bounds.Height * -0.1f),
            radius: bounds.Width * .3f,
            canvas);

        // Interval label, below the circle
        if (interval != null)
        {
            var label = interval.Degree == 1 ? "Root" : interval.Abbreviation;
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