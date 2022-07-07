using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameTranslationGenerator;
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Translation Generator");

			var parser = new Parser();
			using (var reader = new StreamReader(@"/Users/pete_jdv/Downloads/MG/game-list.csv"))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(",");

					// 0 -> Original Name
					// 1 -> Chinese Translation
					// 2 -> Game Code
					// 3 -> Game Type

				    // Parse for English
					parser.Parse(values[0], values[2], values[3]);
				    // Parse for Chinese
					parser.Parse(values[1], values[2], values[3], "cn");


					using (var writer = new StreamWriter(@"/Users/pete_jdv/Downloads/MG/file.yml"))
					{
						// Save Changes
						var serializer = new SerializerBuilder()
						.WithNamingConvention(CamelCaseNamingConvention.Instance)
						.Build();
						serializer.Serialize(writer, parser);
					}
				}
			}

			Console.WriteLine("File Generation Done!, Press Any Key to Exit");
			Console.ReadLine();
		}
	}
