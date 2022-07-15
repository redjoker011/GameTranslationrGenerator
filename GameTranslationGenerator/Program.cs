namespace GameTranslationGenerator;
class Program
{
	static string FilePath = "";
	static string Output = "";

	static void Main(string[] args)
	{
		Console.WriteLine("Initializing Translation Generator....\n");

		var ExitApp = false;

		if (args.Length == 0)
		{
			Console.WriteLine("Invalid Arguments");
			return;
		}

		foreach(var arg in args)
		{
			if(ExitApp)
			{
				break;
			}

			var splittedArgument = arg.Split("=");
			var argumentKey = splittedArgument[0];
			var argumentValue = splittedArgument[1];

			switch(argumentKey)
			{
				case "filePath":
                    FilePath = argumentValue;
					break;
				case "output":
					Output = argumentValue;
					break;
				default:
					Console.WriteLine($"Invalid Command: `{argumentKey}`");
					ExitApp = true;
					break;

			}
		}

		// Check Console App Arguments
		CheckFilePath();
		CheckOutput();

		// var output = "/users/pete_jdv/downloads/mg/file.ymll";
		// var file = "/Users/pete_jdv/Downloads/MG/game-list.csv";

		var parser = new Parser();
		var reader = new Reader(parser);

	    reader.Translate(FilePath, Output);
		ExitApp = !reader.Success;


		if (!ExitApp)
		{
			Console.WriteLine("File Generation Done!, Press Any Key to Exit");
			Console.ReadLine();
		}
	}

	static void CheckFilePath()
	{
		if(String.IsNullOrEmpty(FilePath))
		{
			Console.WriteLine("Missing argument `filePath`");
			return;
		}
  }

	static void CheckOutput()
	{
		if(String.IsNullOrEmpty(FilePath))
		{
			Console.WriteLine("Missing argument `output`");
			return;
		}
  }
}
