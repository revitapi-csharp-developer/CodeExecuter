using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace ConsoleApp1
{
    public class CodeExecutor
    {
        private static void ExecuteCode(string code)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

            if (results.Errors.Count > 0)
            {
                foreach (CompilerError error in results.Errors)
                {
                    Console.WriteLine(error.ErrorText);
                }
            }
            else
            {
                Type program = results.CompiledAssembly.GetType("Program.Program");
                MethodInfo main = program.GetMethod("Main");
                main.Invoke(null, null);
            }
        }
        public static void ExecuteCodeFunction()
        {
            string code = @"using System;

                            namespace Program
                            {
                                public class Program
                                {
                                    public static void Main()
                                    {
                                        int a = 5;
                                        int b = 3;
                                        Console.ReadLine();
                                        Console.WriteLine(a+b);
                                    }
                                }
                            }";

            string code2 = @"using System;

                            namespace Program
                            {
                                public class Program
                                {
                                    public static void Main()
                                    {
                                        int num1 = 0;  
                                        int num2 = 0;  
                                        // Ask the user to type the first number.  
                                        Console.WriteLine(""Type a number, and then press Enter"");  
                                        num1 = Convert.ToInt32(Console.ReadLine());  
                                        // Ask the user to type the second number.  
                                        Console.WriteLine(""Type another number, and then press Enter"");  
                                        num2 = Convert.ToInt32(Console.ReadLine());  
                                        // Ask the user to choose an option.  
                                        Console.WriteLine(""Choose an option from the following list:"");  
                                        Console.WriteLine(""\ta - Add"");  
                                        Console.WriteLine(""\ts - Subtract"");  
                                        Console.WriteLine(""\tm - Multiply"");  
                                        Console.WriteLine(""\td - Divide"");  
                                        Console.Write(""Your option? "");  
                                        // Use a switch statement to do the math.  
                                        switch (Console.ReadLine()) {  
                                            case ""a"":  
                                                Console.WriteLine(""Your result: {num1} + {num2} = "" + (num1 + num2));  
                                                break;  
                                            case ""s"":  
                                                Console.WriteLine(""Your result: {num1} - {num2} = "" + (num1 - num2));  
                                                break;  
                                            case ""m"":  
                                                Console.WriteLine(""Your result: {num1} * {num2} = "" + (num1 * num2));  
                                                break;  
                                            case ""d"":  
                                                Console.WriteLine(""Your result: {num1} / {num2} = "" + (num1 / num2));  
                                                break;  
                                        }  
                                        // Wait for the user to respond before closing.  
                                        Console.Write(""Press any key to close the Calculator console app..."");  
                                        Console.ReadKey();  
                                    }
                                }
                            }";


            // Birbiri ile bağlantılı class yapılarında , veri compile edilirken sorunlar yaşanıyor.
            CodeExecutor.ExecuteCode(code2);
        }
    }
}
