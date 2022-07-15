namespace GameTranslationGenerator;

public class Parser
{
    public Dictionary<string, Dictionary<string, string>> En = new Dictionary<string, Dictionary<string, string>>();
    public Dictionary<string, Dictionary<string, string>> Cn = new Dictionary<string, Dictionary<string, string>>();

    public void Parse(string Title, string GameCode, string GameType, string Locale = "en")
    {
        string normalizedKey = $"_{GameCode}";
        string gameTypeLower = GameType.ToLower();

        if (gameTypeLower == "slot")
        {
            // Pluralize slot -> slots
            gameTypeLower = $"{gameTypeLower}s";
        }

        var prop = En;

        if (Locale != "en")
        {
            prop = Cn;
	      }

        if (!prop.ContainsKey(gameTypeLower))
        {
	          var dict = new Dictionary<string, string> {
	            { normalizedKey, Title.Trim() }
		        };

	          prop.Add(gameTypeLower, dict);
        }
        else if (!prop[key: gameTypeLower].ContainsKey(normalizedKey))
        {
	        prop[key: gameTypeLower].Add(normalizedKey, Title.Trim());
        }
    }
}
