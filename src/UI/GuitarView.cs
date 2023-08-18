using GuitarTheory.Extensions;
using GuitarTheory.UI.Support;

namespace GuitarTheory;

public partial class GuitarView : XGraphicsView
{
    private int StringCount => guitar.Strings.Count;
    private int FretCount => guitar.Frets.Count;

    private readonly Guitar guitar;
    private readonly FretboardOverlay overlay;

    public GuitarView(Guitar guitar, FretboardOverlay overlay)
    {
        this.guitar = guitar;
        this.overlay = overlay;
        overlay.Changed += Invalidate;
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
        try
        {
            ComputeSizes(bounds);
            DrawFretboard(canvas);
            DrawStrings(canvas);
            DrawNotes(canvas);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Drawing error");
        }
    }

    private void DrawFretboard(ICanvas canvas)
    {
        canvas.FillRectangle(FretboardBounds, FretboardPaint);

        foreach (var fret in guitar.Frets)
        {
            var width = fret == 0 ? NutWidth : FretWidth;
            var paint = fret == 0 ? NutPaint : FretPaint;

            canvas.FillRectangle(
                x: GetFretX(fret) - (width / 2),
                y: FretboardBounds.Top,
                width: width,
                height: FretboardBounds.Height,
                paint: paint);

            switch (fret.Number)
            {
                case 3 or 5 or 7 or 9 or 15 or 17:
                    DrawInlay(fret, 0.5f);
                    break;
                case 12:
                    DrawInlay(fret, 0.32f);
                    DrawInlay(fret, 0.68f);
                    break;
            }
        }

        void DrawInlay(Fret fret, float distance)
        {
            var x = GetFingerX(fret);
            var y = FretboardBounds.Top + (FretboardBounds.Height * distance);
            canvas.FillCircle(centerX: x, centerY: y, radius: InlayRadius, InlayPaint);
        }
    }

    private void DrawStrings(ICanvas canvas)
    {
        var sizeInterpolation = new Interpolation( // X = string number, Y = size/height
            from: (X: 1, Y: 2),
            to: (X: StringCount, Y: 4));

        foreach (var str in guitar.Strings)
        {
            var stringSize = (float) sizeInterpolation.GetY(str.Number);
            var y = GetStringY(str) - (stringSize / 2);

            canvas.SetShadow(offset: new SizeF(0, 4), blur: 6f, Colors.Black);

            canvas.FillRectangle(
                x: FretboardBounds.Left + (NutWidth / 2),
                y: y,
                width: FretboardBounds.Width,
                height: stringSize,
                paint: StringPaint);

            canvas.ClearShadow();

            canvas.FillRectangle(
                x: FretboardBounds.Left - (NutWidth / 2),
                y: y,
                width: NutWidth,
                height: stringSize,
                paint: StringPaint);
        }
    }

    private void DrawNotes(ICanvas canvas)
    {
        foreach (var tone in overlay.Tones)
        {
            foreach (var position in guitar.FingerPositions.Where(p => tone.Matches(p.Pitch)))
            {
                var options = NoteOptions.UpDownArrow;
                if (tone.Interval.IsRoot)
                {
                    options |= NoteOptions.Emphasized;
                }
                if (overlay.DisplayInterval)
                {
                    options |= NoteOptions.IntervalLabel;
                }

                DrawingUtils.DrawNote(tone.Note,
                    tone.Interval,
                    center: GetPoint(position),
                    radius: NoteRadius,
                    canvas,
                    options);
            }
        }
    }

    private float GetStringY(GuitarString str)
    {
        return FretboardBounds.Top + StringInset + ((str.Number - 1) * StringSpacing);
    }

    private float GetFretX(Fret fret)
    {
        return FretboardBounds.Left + (fret.Number * FretSpacing);
    }

    private float GetFingerX(Fret fret)
    {
        return GetFretX(fret) - (FretSpacing / 2);
    }

    private PointF GetPoint(FingerPosition position)
    {
        return new PointF(
            x: GetFingerX(position.Fret),
            y: GetStringY(position.String));
    }
}