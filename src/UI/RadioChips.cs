using System.Collections.Immutable;
using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace GuitarTheory;

public class RadioChips<T> : FlexLayout
{
    public event Action<T>? SelectionChanged;

    public static readonly BindableProperty SelectedProperty = BindableProperty.Create(
        propertyName: nameof(Selected),
        returnType: typeof(T),
        declaringType: typeof(RadioChips<T>),
        defaultValue: default,
        propertyChanged: (bindable, _, newValue) => ((RadioChips<T>) bindable).SelectionChanged?.Invoke((T) newValue));

    public T Selected
    {
        get => (T) GetValue(SelectedProperty);
        set => SetValue(SelectedProperty, value);
    }

    public required IEnumerable<(string Name, T Value)> Options
    {
        init
        {
            options = value.ToImmutableArray();
            if (Selected == null && options.Count > 0)
            {
                Selected = options[0].Value;
            }
            Update();
        }
    }

    private readonly IReadOnlyList<(string Name, T Value)> options;

    public RadioChips()
    {
        Wrap = FlexWrap.Wrap;
    }

    private void Update()
    {
        Clear();

        foreach (var option in options)
        {
            var chip = new Chip(text: option.Name)
                .Bind(Chip.IsSelectedProperty,
                    nameof(Selected),
                    source: this,
                    convert: (T? selected) => Equals(selected, option.Value))
                .TapGesture(() => Selected = option.Value);

            Add(chip);
        }
    }

    private class Chip : Border
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            propertyName: nameof(IsSelected),
            returnType: typeof(bool),
            declaringType: typeof(Chip),
            defaultValue: false,
            propertyChanged: (bindable, _, _) => ((Chip) bindable).Update());

        public bool IsSelected
        {
            get => (bool) GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        private static readonly Color SelectedColor = Color.Parse("#006a6a");

        private readonly Label label;

        public Chip(string text)
        {
            StrokeThickness = 2;
            Margin = new Thickness {Right = 2, Bottom = 4};

            label = new Label
            {
                Text = text,
                FontSize = 16,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(horizontalSize: 16, verticalSize: 4),
            };

            Content = label;

            Update();

            this.TapGesture(() => Animate());
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            Update();
        }

        private void Update()
        {
            BackgroundColor = IsSelected ? SelectedColor : Colors.White;
            label.TextColor = IsSelected ? Colors.White : Colors.Black;
            Stroke = label.TextColor;
            StrokeShape = new RoundRectangle {CornerRadius = Height / 2};
            Opacity = IsSelected ? 1 : 0.75;
        }

        private async Task Animate()
        {
            await this.ScaleTo(0.75, length: 125);
            await this.ScaleTo(1, length: 125);
        }
    }
}