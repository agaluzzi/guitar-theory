namespace GuitarTheory;

public class MainPage : ContentPage
{
    public MainPage()
    {
        var guitar = new Guitar(frets: 12);
        Content = new GuitarView(guitar);
    }
}