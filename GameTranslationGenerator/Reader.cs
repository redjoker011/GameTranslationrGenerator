using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameTranslationGenerator;

public class Reader
{
	public bool Success { get; set; } = false;

	private Parser _parser { get; set; }

    public Reader(Parser Service)
    {

		_parser = Service;
    }

    public void Translate(string FilePath, string Output)
    {
        try
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
					_parser.Parse(values[0], values[2], values[3]);
				    // Parse for Chinese
					_parser.Parse(values[1], values[2], values[3], "cn");
				}
			}

			WriteToFile(Output);
		}
		catch(FileNotFoundException e)
		{
			Console.WriteLine("Error: Cannot Find File: {0}", e.FileName);
			return;
		}		
    }

	private void WriteToFile(string Output)
	{
		try
		{
			using (var writer = new StreamWriter($@"{Output}"))
			{
				// Save Changes
				var serializer = new SerializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();
				serializer.Serialize(writer, _parser);
			}
		}
		catch(DirectoryNotFoundException e)
		{
			Console.WriteLine("Error: Directory Not Found! {0}", e.Message);
			return;
		}

		Success = true;
    }
}

