namespace GuitarTheory;

public partial class GuitarView
{
    private static readonly Paint FretboardPaint = PaintFactory.VerticalGradient(
        ("7c503f", 0),
        ("1f0f09", 1));

    private static readonly Paint FretPaint = PaintFactory.HorizontalGradient(
        ("5a5a5a", 0.10),
        ("c9c9c9", 0.45),
        ("c9c9c9", 0.55),
        ("5a5a5a", 0.90));

    private static readonly Paint NutPaint = PaintFactory.VerticalGradient(
        ("ffffe6", 0.10),
        ("ddddc5", 0.90));

    private static readonly Paint StringPaint = PaintFactory.VerticalGradient(
        ("bb6d2f", 0.0),
        ("f6cd79", 0.5),
        ("bb6d2f", 1.0));

    private static readonly Paint InlayPaint = PaintFactory.LinearGradient(
        from: (0, 0),
        to: (1, 1),
        ("afafaf", 0.2),
        ("ffffff", 0.8));
}