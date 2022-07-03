using System;
using System.Reflection;
using System.IO;

namespace Lab12
{
    public static class Reflector
    {
        public static void AllAboutClass(string className)
        {
            var type = Type.GetType(className, false, true);
            var memberInfos = type.GetMembers();
            using (var fstream = new FileStream("class.txt", FileMode.Create))
            {
                var writer = new StreamWriter(fstream);
                foreach (MemberInfo member in memberInfos)
                {
                    Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
                    writer.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
                }
                writer.Close();
            }
        }

        public static void PublicMethod(string className)
        {
            var type = Type.GetType(className, false, true);
            var methods = type.GetMethods();
            using (var fstream = new FileStream("methods.txt", FileMode.Create))
            {
                var writer = new StreamWriter(fstream);
                Console.WriteLine($"Методы {className}:");
                writer.WriteLine($"Методы {className}:");
                foreach (MethodInfo method in methods)
                {
                    if (method.IsPublic)
                    {
                        Console.Write($"*{method.ReturnType.Name.ToLower()} {method.Name}(");
                        writer.Write($"*{method.ReturnType.Name.ToLower()} {method.Name}(");
                        ParameterInfo[] parameters = method.GetParameters();
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                            writer.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                            if (i + 1 < parameters.Length)
                            {
                                Console.Write(", ");
                                writer.Write(", ");
                            }
                        }
                        Console.WriteLine(")");
                        writer.WriteLine(")");
                    }
                    
                }
                writer.Close();
            }
        }

        public static void Field(string className)
        {
            var type = Type.GetType(className, false, true);
            var fieldInfo = type.GetFields();
            var propertyInfos = type.GetProperties();
            using (var fstream = new FileStream("fields.txt", FileMode.Create))
            {
                var writer = new StreamWriter(fstream);
                Console.WriteLine("Поля:");
                writer.WriteLine("Поля:");
                foreach (FieldInfo field in fieldInfo)
                {
                    Console.WriteLine($"*{field.FieldType} {field.Name}");
                    writer.WriteLine($"*{field.FieldType} {field.Name}");
                }

                Console.WriteLine("Свойства:");
                writer.WriteLine("Свойства:");
                foreach (PropertyInfo prop in propertyInfos)
                {
                    Console.WriteLine($"*{prop.PropertyType} {prop.Name}");
                    writer.WriteLine($"*{prop.PropertyType} {prop.Name}");
                }
                writer.Close();
            }       
        }
        public static void Interface(string className)
        {
            var type = Type.GetType(className, false, true);
            using (var fstream = new FileStream("interface.txt", FileMode.Create))
            {
                var writer = new StreamWriter(fstream);
                Console.WriteLine("Реализованные интерфейсы:");
                writer.WriteLine("Реализованные интерфейсы:");
                foreach (Type i in type.GetInterfaces())
                {
                    Console.WriteLine(i.Name);
                    writer.WriteLine(i.Name);
                }
                writer.Close();
            }
        }
        public static void MethodForType(string className, Type parametr)
        {
            var type = Type.GetType(className, false, true);
            var methods = type.GetMethods();         
            ParameterInfo[] parameters;
            for (var i = 0; i < methods.Length; i++)
            {
                parameters = methods[i].GetParameters();
                foreach (ParameterInfo j in parameters)
                {
                    if (j.ParameterType == parametr)
                    {
                        Console.WriteLine(methods[i].Name);
                        break;
                    }
                }
            }      
        }
        static public void Voke(string className, string methode)
        {
            var type = Type.GetType(className, false, true);
            var fstream = new FileStream("param.txt", FileMode.OpenOrCreate);
            var read = new StreamReader(fstream);
            var parametr = read.ReadToEnd();           
            var parametrs = new object[] { parametr};
            var myMethod = Activator.CreateInstance(type);
            var method = type.GetMethod(methode);
            var result = method.Invoke(myMethod, parametrs);
            Console.WriteLine(result);
        }
    }
}
