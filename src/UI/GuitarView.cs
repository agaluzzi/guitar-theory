using GuitarTheory.Extensions;
using GuitarTheory.UI.Support;

namespace GuitarTheory;

public partial class GuitarView : GraphicsView, IDrawable
{
    private int StringCount => guitar.Strings.Count;
    private int FretCount => guitar.Frets.Count;

    private readonly Guitar guitar;

    public GuitarView(Guitar guitar)
    {
        this.guitar = guitar;
        Drawable = this;
    }

    public void Draw(ICanvas canvas, RectF bounds)
    {
        ComputeSizes(bounds);
        DrawFretboard(canvas);
        DrawStrings(canvas);
    }

    private void DrawFretboard(ICanvas canvas)
    {
        canvas.FillRectangle(FretboardBounds, FretboardPaint);

        // Nut
        canvas.FillRectangle(
            x: FretboardBounds.Left,
            y: FretboardBounds.Top,
            width: NutWidth,
            height: FretboardBounds.Height,
            NutPaint);

        // Frets and inlays...
        for (var i = 1; i <= FretCount; i++)
        {
            var x = FretboardBounds.Left + (i * FretSpacing);
            canvas.FillRectangle(x, FretboardBounds.Top, FretWidth, FretboardBounds.Height, FretPaint);

            var inlayX = x - (FretSpacing / 2);

            switch (i)
            {
                case 3 or 5 or 7 or 9 or 15 or 17:
                    DrawInlay(
                        cx: inlayX,
                        cy: FretboardBounds.Center.Y);
                    break;
                case 12:
                    DrawInlay(
                        cx: inlayX,
                        cy: FretboardBounds.Top + StringInset + (StringSpacing * 1.5f));
                    DrawInlay(
                        cx: inlayX,
                        cy: FretboardBounds.Bottom - StringInset - (StringSpacing * 1.5f));
                    break;
            }
        }

        void DrawInlay(float cx, float cy)
        {
            canvas.FillCircle(centerX: cx, centerY: cy, radius: InlayRadius, InlayPaint);
        }
    }

    private void DrawStrings(ICanvas canvas)
    {
        var sizeInterpolation = new Interpolation( // X = string number, Y = size/height
            from: (X: 1, Y: 2),
            to: (X: StringCount, Y: 4));

        var y = FretboardBounds.Top + StringInset;
        for (var i = 1; i <= StringCount; i++)
        {
            var stringSize = (float) sizeInterpolation.GetY(i);

            canvas.SetShadow(offset: new SizeF(0, 4), blur: 6f, Colors.Black);

            canvas.FillRectangle(
                x: FretboardBounds.Left + NutWidth,
                y: y - (stringSize / 2),
                width: FretboardBounds.Width,
                height: stringSize,
                paint: StringPaint);

            canvas.ClearShadow();

            canvas.FillRectangle(
                x: FretboardBounds.Left,
                y: y - (stringSize / 2),
                width: NutWidth,
                height: stringSize,
                paint: StringPaint);

            y += StringSpacing;
        }
    }
}