using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace VisualInformationSystemDesigner.Model
{
	public class Interpreter
	{
		public Interpreter()
		{

		}

		public enum VariableType
		{
			Integer,
			Double,
			String,
			Null
		}

		public class Variable
		{
			public VariableType Type { get; }
			public object Value { get; }

			public Variable(VariableType type, object value)
			{
				Type = type;
				Value = value;
			}
		}


		private readonly Dictionary<string, Variable> variables = new Dictionary<string, Variable>();

		public string Interpret(string? code)
		{
			if (code == null)
			{
				return "";
			}

            var regex = new Regex(@"(?:[^\s""]+|""[^""]*"")+");
            string output = "";

			string[] lines = code.Split('\n');

            foreach (string line in lines)
			{
                string[] tokens = regex.Matches(line).Cast<Match>().Select(x => x.Value.Trim('"')).ToArray();

                for (int i = 0; i < tokens.Length; i++)
				{
					if (tokens[i] == "int" || tokens[i] == "double" || tokens[i] == "string")
					{
						VariableType type = VariableType.Null;

						if (tokens[i] == "int")
						{
							type = VariableType.Integer;
						}
						else if (tokens[i] == "double")
						{
							type = VariableType.Double;
						}
						else if (tokens[i] == "string")
						{
							type = VariableType.String;
						}

						string name = tokens[i + 1];
						object? value = null;

						if (type == VariableType.Integer)
						{
							value = Convert.ChangeType(tokens[i + 3], typeof(int));
						}
						else if (type == VariableType.Double)
						{
                            value = double.Parse(tokens[i + 3], CultureInfo.InvariantCulture);
						}
						else
						{
							value = tokens[i + 3];
						}

						variables[name] = new Variable(type, value);
					}
					else if (tokens[i] == "print")
					{
						string name = tokens[i + 1];

						if (variables.ContainsKey(name))
						{
							//Console.WriteLine(variables[name].Value);
							output += variables[name].Value + "\n";
						}
						else
						{
                            output += $"Ошибка: Переменная '{name}' не найдена." + "\n";
                            //Console.WriteLine($"Error: Variable '{name}' not found.");
                        }
					}
				}
			}

			return output;
		}
	}
}