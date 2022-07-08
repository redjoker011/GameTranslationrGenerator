namespace GameTranslationGenerator;
class Program
{
	static string FilePath = "";
	static string Output = "";

	static void Main(string[] args)
	{
		Console.WriteLine("Initializing Translation Generator....\n");

		var ExitApp = false;

		var output = "/Users/pete_jdv/Downloads/MG/file.yml";
		var file = "/Users/pete_jdv/Downloads/MG/game-list.csv";

		var parser = new Parser();
		new Reader(parser).Translate(file, output);

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
