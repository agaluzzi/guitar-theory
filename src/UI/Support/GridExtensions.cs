namespace GuitarTheory.UI.Support;

public static class GridExtensions
{
    public static T AddRow<T>(this T grid, GridLength height, out int row) where T : Grid
    {
        row = grid.RowDefinitions.Count;
        grid.AddRowDefinition(new RowDefinition(height));
        return grid;
    }

    public static T AddColumn<T>(this T grid, GridLength width, out int column) where T : Grid
    {
        column = grid.ColumnDefinitions.Count;
        grid.AddColumnDefinition(new ColumnDefinition(width));
        return grid;
    }
}