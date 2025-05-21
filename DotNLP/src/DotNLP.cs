using System.Text;
using System.Text.RegularExpressions;

namespace DotNLP;

public class DotNLP
{
	public IEnumerable<string> WordTokenize(string text)
	{
		IList<string> textTokens = text.Split(" ");
		IList<string> resultTokens = [];

		foreach (var token in textTokens)
		{
			if (IsContractionOrPossessive(token) && !IsSpecialException((token)))
			{
				HandleContractionsPossessives(resultTokens, token);
			}

			else if (token.Any(char.IsPunctuation) && !IsSpecialException((token)))	
			{
				HandlePunctuation(resultTokens, token);
			}

			else
			{
				resultTokens.Add(token);
			}
		}

		return resultTokens;
	}

	private static void HandlePunctuation(IList<string> tokens, string token)
	{
		
		var puncIndex = token.IndexOf(token.FirstOrDefault(char.IsPunctuation));
		tokens.Add(token[..puncIndex]);

		if (token[puncIndex..] == "...")
		{
			tokens.Add("...");
		}
		else
		{
			foreach (var c in token[puncIndex..])
			{
				tokens.Add(c.ToString());
			}
		}
	}

	private static void HandleContractionsPossessives(IList<string> tokens, string token)
	{
		if (token.Count(c => c.ToString() == "'") == 1)
		{
			if (token.EndsWith("n't"))
			{
				var i = token.IndexOf("n't", StringComparison.Ordinal);
				tokens.Add(token[..i]);
				tokens.Add("n't");
			}
			else
			{
				var i = token.IndexOf('\'');
				tokens.Add(token[..i]);
				tokens.Add(token[i..]);
			}
		}
	}

	private static bool IsContractionOrPossessive(string token)
	{
		token = token.ToLower();
		return token.EndsWith("'s") ||
		       token.EndsWith("'re") ||
		       token.EndsWith("'ve") ||
		       token.EndsWith("'ll") ||
		       token.EndsWith("'d") ||
		       token.EndsWith("n't") ||
		       token.EndsWith("'m");
	}

	private static bool IsSpecialException(string token)
	{
		token = token.ToLower();
		return token == "ain't" ||
		       token == "y'all" ||
		       token == "ma'am";
	}
}