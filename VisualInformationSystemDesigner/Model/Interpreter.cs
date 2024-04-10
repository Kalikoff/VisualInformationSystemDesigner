using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

			string output = "";

			code = code.Replace("\r", "");

			string[] lines = code.Split('\n');

			foreach (string line in lines)
			{
				string[] tokens = line.Split(' ');

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
						object value;

						if (type != VariableType.String)
						{
							value = Convert.ChangeType(tokens[i + 3], type == VariableType.Integer ? typeof(int) : typeof(double));
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
							Console.WriteLine($"Error: Variable '{name}' not found.");
						}
					}
				}
			}

			return output;
		}
    }
}