using CommunityToolkit.Maui.Markup;
using GuitarTheory.UI.Support;
using Microsoft.Maui.Layouts;

namespace GuitarTheory;

public class MainPage : ContentPage
{
    private Instrument instrument = Instruments.Default;
    private readonly FretboardOverlay overlay = new();
    private readonly AbsoluteLayout rootLayout = new();

    public MainPage()
    {
        BackgroundColor = Colors.SlateGray;
        Content = rootLayout;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        UpdateLayout();
        base.OnSizeAllocated(width, height);
    }

    private void UpdateLayout()
    {
        rootLayout.Clear();
        rootLayout.Add(BuildLayout().LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.SizeProportional));
    }

    private Grid BuildLayout()
    {
        var titleLabel = BuildTitleLabel();
        var instrumentPicker = BuildInstrumentPicker();
        var chromaticPanel = new ChromaticPanel(overlay);
        var optionPanel = new OptionPanel(overlay);
        var guitarView = new GuitarView(instrument, overlay);

        var layout = new Grid()
            .AddRow(GridLength.Auto, out var titleRow)
            .AddRow(GridLength.Star, out var controlsRow)
            .AddRow(new GridLength(3, GridUnitType.Star), out var guitarRow)
            .AddRow(GridLength.Auto, out var optionsRow);

        layout.Add(titleLabel.Row(titleRow).Column(0));
        layout.Add(instrumentPicker.Row(titleRow).Column(0).Start().CenterVertical().Margins(left: 10));
        layout.Add(chromaticPanel.Row(controlsRow).Column(0));
        layout.Add(optionPanel.Row(optionsRow).Column(0));
        layout.Add(guitarView.Row(guitarRow).Column(0));

        return layout;
    }

    private View BuildTitleLabel()
    {
        var label = new Label
        {
            Text = overlay.Title,
            FontSize = 28,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White,
        }.TextCenter();
        overlay.Changed += () =>
        {
            label.Text = overlay.Title;
        };
        return label;
    }

    private View BuildInstrumentPicker()
    {
        var button = new Button
        {
            Text = instrument.Name,
            TextTransform = TextTransform.Uppercase,
            FontSize = 20,
            FontAttributes = FontAttributes.Bold,
            BackgroundColor = Color.Parse("#006a6a"),
            TextColor = Colors.White,
            BorderColor = Colors.White,
            BorderWidth = 2,
            CornerRadius = 12,
            Padding = new Thickness(horizontalSize: 20, verticalSize: 10),
        };

        button.TapGesture(OnTap);

        return button;

        void OnTap()
        {
            var instrumentNames = Instruments.All.Select(i => i.Name).ToArray();

            DisplayActionSheet(
                    title: "Select Instrument",
                    cancel: null,
                    destruction: null,
                    instrumentNames)
                .ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        var name = task.Result;
                        instrument = Instruments.All.First(i => i.Name == name);
                        MainThread.BeginInvokeOnMainThread(UpdateLayout);
                    }
                });
        }
    }
}