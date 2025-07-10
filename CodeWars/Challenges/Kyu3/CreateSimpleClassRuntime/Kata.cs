using System.Reflection;
using System.Reflection.Emit;

namespace Challenges.Kyu3.CreateSimpleClassRuntime;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/589394ae1a880832e2000092">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5893a180ec8c66e525001eb1/groups/6806793771aee9dcbe7be951">here</see>
/// </summary>
public static class Kata
{
    private static ModuleBuilder runtimeModule;
    static Kata()
    {
        AssemblyBuilder asmBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("RuntimeAssembly"), AssemblyBuilderAccess.Run);
        runtimeModule = asmBuilder.DefineDynamicModule("RuntimeAssembly");
    }
    
    public static bool DefineClass(string className, Dictionary<string, Type> properties, ref Type actualType)
    {
        if (runtimeModule.GetType(className) is not null) return false;

        TypeBuilder typeBuilder = runtimeModule.DefineType(className, TypeAttributes.Public);
        foreach ((string name, Type type) in properties)
        {
            //define backing field
            FieldBuilder field = typeBuilder.DefineField($"m_{name}", type, FieldAttributes.Private);
            
            //define property
            PropertyBuilder property = typeBuilder.DefineProperty(name, PropertyAttributes.HasDefault, type, null);
            
            //define getter/setter
            MethodAttributes getsetAttrib =
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            
            MethodBuilder getter = typeBuilder.DefineMethod($"get_{name}",
                getsetAttrib, type,
                Type.EmptyTypes);
            ILGenerator getIL = getter.GetILGenerator();
            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, field);
            getIL.Emit(OpCodes.Ret);

            MethodBuilder setter = typeBuilder.DefineMethod($"set_{name}", getsetAttrib, null, [type]);
            ILGenerator setIL = setter.GetILGenerator();
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, field);
            setIL.Emit(OpCodes.Ret);
            
            property.SetGetMethod(getter);
            property.SetSetMethod(setter);
        }

        actualType = typeBuilder.CreateType();
        return true;
    }

    private static void DefineProperty(string name, Type type)
    {
        
    }
}