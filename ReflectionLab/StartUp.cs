using System;

namespace ReflectionLab
{
    [Author("Boyan")]
    public class StartUp
    {
        //  static classes cannot be instantiated or inherited
        //  static classes are marked as sealed and abstract by compiler in the output MSIL
        //  all members of static classes must be static as well
        //  only static classes can host extension methods
        //  static classes cannot be used as generic type arguments

        [Author("Boyan")]
        public static void Main()
        {
            const string className = "Hacker";
  

            Spy spy = new Spy();
            string result = spy.StealFieldInfo(className, "username", "password");
            Console.WriteLine(result);
            Console.WriteLine();

            string secondResult = spy.AnalyzeAccessModifiers(className);
            Console.WriteLine(secondResult);
            Console.WriteLine();

            string thirdResult = spy.RevealPrivateMethods(className);
            Console.WriteLine(thirdResult);
            Console.WriteLine();

            Console.WriteLine(spy.GetGetters(className));
            Console.WriteLine();
            Console.WriteLine(spy.GetSetters(className));
            Console.WriteLine();

            var tracker = new Tracker();
            tracker.p
        }
    }
}
