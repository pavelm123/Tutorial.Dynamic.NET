using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(List<dynamic>));// выдаст System.Collections.Generic.List`1[System.Object]
            
            dynamic d = "test";
            Console.WriteLine(d.GetType());// выдает System.String

            object objExample = 10;
            dynamic dynamicExample = 10;
            Console.WriteLine(dynamicExample.GetType());
            Console.WriteLine(objExample.GetType());
            objExample = (int)objExample + 10; // нужен typecast
            dynamicExample = dynamicExample + 10; // не нужен type cast
            dynamicExample = "test";
            dynamicExample = dynamicExample + 10; // не нужен type cast
            Console.WriteLine(dynamicExample);// выдает "test10"

            //Все вместе в перемешку - и Object, и var и dynamic - так тоже можно:
            dynamic dynamicObject = new Object();
            var anotherObject = dynamicObject; // What’s the type of anotherObject? The answer is: dynamic

            //Remember that dynamic is in fact a static type in the C# type system, so the compiler infers this type for the anotherObject. It’s important to understand that the var keyword is just an instruction for the compiler to infer the type from the variable’s initialization expression; var is not a type.

            dynamic expando = new ExpandoObject();
            expando.SampleProperty = "This property was added at run time";
            expando.SampleMethod = (Action)(() => Console.WriteLine(expando.SampleProperty));
            // Action описан как public delegate void Action(), можно использовать так:
            // Action showMethod = () => testName.DisplayToWindow();
            // или так: Action showMethod = delegate() { testName.DisplayToWindow();} ;
            expando.SampleMethod();
        }
    }
}
