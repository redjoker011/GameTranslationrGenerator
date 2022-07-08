using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameTranslationGenerator;

public class Reader
{
	Parser Parser { get; set; }

    public Reader(Parser Service)
    {

		Parser = Service;
    }

    public void Translate(string FilePath, string Output)
    {
		using (var reader = new StreamReader($@"{FilePath}"))
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
				Parser.Parse(values[0], values[2], values[3]);
			    // Parse for Chinese
				Parser.Parse(values[1], values[2], values[3], "cn");


				WriteToFile(Output);
			}
		}
    }

	private void WriteToFile(string Output)
	{
		using (var writer = new StreamWriter($@"{Output}"))
		{
			// Save Changes
			var serializer = new SerializerBuilder()
			.WithNamingConvention(CamelCaseNamingConvention.Instance)
			.Build();
			serializer.Serialize(writer, Parser);
		}
    }
}

