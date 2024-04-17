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

			foreach (string line in lines)
			{
				string[] tokens = regex.Matches(line).Cast<Match>().Select(x => x.Value.Trim('"')).ToArray();

				for (int i = 0; i < tokens.Length; i++)
				{
					if (_validVariableType.Contains(tokens[0]))
					{
						VariableType type = VariableType.Null;
						object? value = null;

						switch (tokens[i])
						{
							case "int":
								type = VariableType.Integer;
								value = Convert.ChangeType(tokens[i + 3], typeof(int));
								break;
							case "double":
								type = VariableType.Double;
								value = double.Parse(tokens[i + 3], CultureInfo.InvariantCulture);
								break;
							case "string":
								type = VariableType.String;
								value = tokens[i + 3];
								break;
						}

						string name = tokens[i + 1];
						variables[name] = new Variable(type, value);

						break;
					}
					else if (tokens[0] == "print")
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

						break;
					}
					else
					{
						return $"Ошибка: Такой команды не существует '{tokens[i]}'!" + "\n";
					}
				}
			}

			return output;
		}
	}
}