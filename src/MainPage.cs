using GuitarTheory.UI.Support;

namespace GuitarTheory;

public class MainPage : ContentPage
{
    private readonly Guitar guitar = new(frets: 13);
    private readonly FretboardOverlay overlay = new();

    public MainPage()
    {
        BackgroundColor = Colors.SlateGray;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        Content = BuildLayout();
        base.OnSizeAllocated(width, height);
    }

    private Grid BuildLayout()
    {
        var guitarView = new GuitarView(guitar, overlay);
        var controlPanel = new ControlPanel(overlay);

        var layout = new Grid()
            .AddRow(GridLength.Star, out var notesRow)
            .AddRow(new GridLength(2, GridUnitType.Star), out var guitarRow)
            .AddColumn(GridLength.Star, out var mainColumn);

        layout.Add(controlPanel, row: notesRow, column: mainColumn);
        layout.Add(guitarView, row: guitarRow, column: mainColumn);
        
        return layout;
    }
}