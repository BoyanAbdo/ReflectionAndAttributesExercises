using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionLab
{
    public class Spy
    {
        private const string currentNamespace = "ReflectionLab";

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType($"{currentNamespace}.{investigatedClass}");

            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType($"{currentNamespace}.{className}");

            var classFieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);

            var classPublicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            var classNonPublicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);


            StringBuilder sb = new StringBuilder();

            foreach (var field in classFieldsInfo.Where(f => f.IsPublic))
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var getter in classPublicMethodsInfo.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} have to be public!");
            }

            foreach (var setter in classNonPublicMethodsInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType($"{currentNamespace}.{className}");

            var classNonPublicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var baseClassName = classType.BaseType.Name;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {baseClassName}");

            foreach (var privateMethod in classNonPublicMethodsInfo.Where(m => m.IsPrivate))
            {
                sb.AppendLine($"{privateMethod.Name}");
            }


            return sb.ToString().Trim();
        }


        public string GetGetters(string className)
        {
            Type classType = Type.GetType($"{currentNamespace}.{className}");
            var classMethods = classType.GetMethods(
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (var getter in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            return sb.ToString().Trim();
        }

        public string GetSetters(string className)
        {
            Type classType = Type.GetType($"{currentNamespace}.{className}");
            var classMethods = classType.GetMethods(
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (var setter in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }



    }
}
