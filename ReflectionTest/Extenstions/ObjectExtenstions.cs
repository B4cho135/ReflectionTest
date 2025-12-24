using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Extenstions
{
    public static class ObjectExtenstions
    {
        public static void PrintObjectStructure(this object o, string indentation = "")
        {
            if (o == null)
            {
                Console.WriteLine("null");
                return;
            }

            var type = o.GetType();
            var properties = type.GetProperties();

            Console.WriteLine($"{indentation}Object of Class \"{type.FullName}\"");
            Console.WriteLine($"{indentation}--------------------------------");

            var propIndent = indentation + "    ";

            foreach (var property in properties)
            {
                // skip indexers
                if (property.GetIndexParameters().Length > 0)
                    continue;

                var value = property.GetValue(o);

                if (IsSimpleType(property.PropertyType))
                {
                    Console.WriteLine($"{propIndent}{property.Name}=\"{value}\"");
                }
                else
                {
                    if (value is null)
                    {
                        Console.WriteLine($"{propIndent}{property.Name}=null");
                    }
                    else
                    {
                        Console.WriteLine($"{propIndent}{property.Name}:");
                        PrintObjectStructure(value, propIndent + "    ");
                    }
                }
            }
        }

        private static bool IsSimpleType(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;

            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(decimal)
                || type == typeof(DateTime)
                || type == typeof(DateTimeOffset)
                || type == typeof(Guid)
                || type == typeof(TimeSpan);
        }
    }
}
