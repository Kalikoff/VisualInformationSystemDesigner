using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using MvvmHelpers;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.CustomElements.Console
{
    public class ConsoleViewModel : BaseViewModel
    {
        private string? _source;
		private string? _consoleOutput;
		private string? _commandText;

		public string? Source
        {
            get { return _source; }
            set
            {
                if (_source != value)
                {
                    _source = value;
                    OnPropertyChanged(nameof(Source));
                }
            }
        }
		public string? ConsoleOutput
		{
			get { return _consoleOutput; }
			set
			{
				if (_consoleOutput != value)
				{
					_consoleOutput = value;
					OnPropertyChanged(nameof(ConsoleOutput));
				}
			}
		}
		public string? CommandText
		{
			get { return _commandText; }
			set
			{
				if (_commandText != value)
				{
					_commandText = value;
					OnPropertyChanged(nameof(CommandText));
				}
			}
		}

		public ConsoleViewModel()
        {
			ProcessCommand = new RelayCommand(ProcessCommandExecute);
        }

		public ICommand ProcessCommand { get; }

		private void ProcessCommandExecute(object obj)
		{
			string? command = CommandText?.Trim();

			if (command == null)
			{
				return;
			}

			if (command == "/start")
			{
                //Interpreter interpreter = new Interpreter();
                //ConsoleOutput += interpreter.Interpret(Source) + "\n";

                //var interpreter = new InterpreterImplementation();
                CompileAndRun(Source);
            }
			else if (command == "/clear")
			{
				ConsoleOutput = "";
			}
			else
			{
				ConsoleOutput += "Неизвестная команда.\n";
			}

			CommandText = "";
		}



		public void UpdateSource(string source)
        {
            Source = source;
        }



        public string CompileAndRun(string source)
        {
            string printCode = @"
                public static class Print
                {
                    public static string Line(string str)
                    {
                        return str;
                    }
                }
            ";
            // Ваша строка с кодом на C#
            //    string code = @"
            //    using System;

            //    public class DynamicClass
            //    {
            //        public string GetMessage()
            //        {
            //            return ""Этот код был выполнен динамически!"";
            //        }
            //    }
            //";

            string code = @source + "\n" + printCode;

            // Создание синтаксического дерева из строки кода
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

            // Компиляция кода
            CSharpCompilation compilation = CSharpCompilation.Create("DynamicAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddSyntaxTrees(syntaxTree);

            using var ms = new MemoryStream();

            // Компиляция в память
            var result = compilation.Emit(ms);

            if (!result.Success)
            {
                string errors = "";

                // Если есть ошибки, выводим их в консоль
                foreach (var diagnostic in result.Diagnostics)
                {
                    errors += diagnostic.GetMessage() + "\n";
                }

                return errors;
            }

            // Загрузка сборки и выполнение кода
            ms.Seek(0, SeekOrigin.Begin);
            var assembly = Assembly.Load(ms.ToArray());

            var mainType = assembly.GetType("Program");
            dynamic instanceMain = Activator.CreateInstance(mainType);
            instanceMain.Main();

            var printType = assembly.GetType("Print");
             dynamic printInstance = Activator.CreateInstance(printType);
            string printResult = printInstance.Line("Hello World");

            ConsoleOutput += printResult + "\n";

            return "";
        }

    }
}