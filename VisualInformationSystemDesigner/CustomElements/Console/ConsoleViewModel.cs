using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisualInformationSystemDesigner.Model;
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
				Interpreter interpreter = new Interpreter();
				ConsoleOutput += interpreter.Interpret(Source) + "\n";
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





    }
}