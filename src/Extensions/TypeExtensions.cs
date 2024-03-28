using System.Reflection;

namespace GuitarTheory;

public static class TypeExtensions
{
    public static IEnumerable<T> GetPublicStaticFields<T>(this Type type)
    {
        return type.GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(field => field.FieldType.IsAssignableTo(typeof(T)))
            .Select(field => field.GetValue(obj: null))
            .OfType<T>();
    }
}