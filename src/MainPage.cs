namespace GuitarTheory;

public class MainPage : ContentPage
{
    public MainPage()
    {
        var guitar = new Guitar(frets: 13);
        var overlay = new FretboardOverlay();
        Content = new GuitarView(guitar, overlay);
    }
}