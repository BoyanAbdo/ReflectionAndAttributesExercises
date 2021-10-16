using System;
using System.Reflection;
using System.Text;

namespace ReflectionAttributesDemo
{
//    The ability of a programming language to be its own metalanguage
//Programs can examine information about themselves


    public class Program
    {
        public static void Main(string[] args)
        {
            var properties = typeof(Cat).GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
            }
            Console.WriteLine();


            var cat = new Cat();
            var type = cat.GetType();

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.GetValue(cat) != null)
                {
                    Console.WriteLine("value = " + fieldInfo.GetValue(cat));
                }
                Console.WriteLine(fieldInfo.Name);
            }

            var sbType = Type.GetType("System.Text.StringBuilder");
            StringBuilder sbInstance =
                 (StringBuilder)Activator.CreateInstance(sbType);
            StringBuilder sbInstCapacity = (StringBuilder)Activator
                 .CreateInstance(sbType, new object[] { 10 });


            FieldInfo field = type.GetField("name");
            FieldInfo[] publicFields = type.GetFields();
            FieldInfo[] allFields = type.GetFields(
                     BindingFlags.Static |
                     BindingFlags.Instance |
                     BindingFlags.Public |
                     BindingFlags.NonPublic);


        }
    }
}
