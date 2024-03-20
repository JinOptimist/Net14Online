
using SendboxForReflection;
using System.Reflection;

var typeOfSweets = typeof(Sweets);

var properties = typeOfSweets.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
foreach (var property in properties)
{
    Console.WriteLine($"{property.Name}: {property.FieldType.Name}");
}

