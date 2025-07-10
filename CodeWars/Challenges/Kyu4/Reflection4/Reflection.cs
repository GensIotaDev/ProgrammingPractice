using System.Reflection;

namespace Challenges.Kyu4.Reflection4;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/57853f88a1b8d5c4030001de">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/57855d45bf6a1ede3f0003c2/groups/6814926a63ee5ac6edd809bd">here</see>
/// </summary>
public static class Reflection
{
    public static string InvokeMethod(string typeName)
    {
        if (string.IsNullOrEmpty(typeName)) return typeName;
        
        var type = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(a => !a.IsDynamic)
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.FullName == typeName);

        if (type is null) return null;
        
        foreach (var c in type.GetConstructors())
        {
            Console.WriteLine($"constructor: params {c.GetParameters()}");
        }
        
        var parameters = type
            .GetConstructors()
            .Single()
            .GetParameters()
            .Select(p => (object)null)
            .ToArray();
        
        var obj = Activator.CreateInstance(type, parameters);
        var method = type
            .GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
            .First(m => m.ReturnType == typeof(string));
        
        return (string)method.Invoke(obj, null);
        if (method.Invoke(obj, null) is string output)
        {
            return output;
        }
        return null;
    }
}