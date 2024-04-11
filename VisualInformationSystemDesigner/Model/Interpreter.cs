using System.Globalization;
using System.Text.RegularExpressions;

namespace VisualInformationSystemDesigner.Model
{
	public class Interpreter
	{
		public Interpreter()
		{

		}

		/// <summary>
		/// Текстовые типы данных
		/// </summary>
		private readonly List<string> _validVariableType = ["int", "double", "string"];

		/// <summary>
		/// Представление доступных типов данных
		/// </summary>
		public enum VariableType
		{
			Integer,
			Double,
			String,
			Null
		}

		/// <summary>
		/// Класс "Переменная"
		/// </summary>
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

		/// <summary>
		/// Словарь всех переменных программы
		/// </summary>
		private readonly Dictionary<string, Variable> variables = new();

		public string Interpret(string? code)
		{
			if (code == null)
			{
				return "";
			}

			var regex = new Regex(@"(?:[^\s""]+|""[^""]*"")+");
			string output = "";

			string[] lines = code.Split('\n');

            for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
            {
                string line = lines[lineNumber];
                string[] tokens = regex.Matches(line).Cast<Match>().Select(x => x.Value.Trim('"')).ToArray();

				if (_validVariableType.Contains(tokens[0]))
				{
					VariableType type = VariableType.Null;
					object? value = null;

					switch (tokens[0])
					{
						case "int":
							type = VariableType.Integer;
							value = Convert.ChangeType(tokens[3], typeof(int));
							break;
						case "double":
							type = VariableType.Double;
							value = double.Parse(tokens[3], CultureInfo.InvariantCulture);
							break;
						case "string":
							type = VariableType.String;
							value = tokens[3];
							break;
					}

					string name = tokens[1];
					variables[name] = new Variable(type, value);

					break;
				}
				else if (tokens[0] == "print")
				{
					string name = tokens[1];

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

					break;
				}
				else if (tokens[0] == "for")
				{
                    if (tokens.Length != 4 || tokens[2] != "in")
                    {
                        return "Ошибка в синтаксисе цикла 'for'!" + "\n";
                    }

                    string counterName = tokens[1];
                    int iterations;

                    if (int.TryParse(tokens[3], out iterations))
                    {
                        for (int i = 0; i < iterations; i++)
                        {
                            variables[counterName] = new Variable(VariableType.Integer, i);
                            string loopBody = "";
                            int braceCount = 0;
                            while (lineNumber < lines.Length)
                            {
                                line = lines[lineNumber];
                                int startIndex = line.IndexOf('{');
                                if (startIndex != -1)
                                {
                                    braceCount++;
                                }
                                int endIndex = line.IndexOf('}');
                                if (endIndex != -1)
                                {
                                    braceCount--;
                                }
                                loopBody += line;
                                if (braceCount == 0)
                                {
                                    break;
                                }
                                lineNumber++;
                            }
                            output += Interpret(loopBody);
                        }
                    }
					else
					{
						return $"Ошибка: Такой команды не существует '{tokens}'!" + "\n";
					}
				}

			}

			return output;
		}
	}
}