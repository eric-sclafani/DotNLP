using System.Text;
using System.Text.RegularExpressions;

namespace DotNLP.Tokenizer;

public partial class Tokenizer
{
	public static IEnumerable<string> WordTokenize(string text)
	{
		IList<string> textTokens = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		IList<string> resultTokens = [];

		foreach (var token in textTokens)
		{
			if (IsContractionOrPossessive(token) && !IsSpecialException((token)))
			{
				HandleContractionsPossessives(resultTokens, token);
			}

			else if (PuncRegex().IsMatch(token) && !IsSpecialException((token)))
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
		if (DecimalRegex().IsMatch(token))
		{
			var s = DecimalRegex().Replace(token, "");
			if (!string.IsNullOrWhiteSpace(s))
			{
				tokens.Add(s);
			}
			tokens.Add(DecimalRegex().Match(token).ToString());
		}
		else if (AbbrevRegex().IsMatch(token))
		{
			tokens.Add(AbbrevRegex().Match(token).ToString());
			var s = AbbrevRegex().Replace(token, "");
			if (!string.IsNullOrWhiteSpace(s))
			{
				tokens.Add(s);
			}
		}
		else
		{
			// need to preserve order of where the punc is in the token
			var word = new StringBuilder("");
			for (var i = 0; i < token.Length; i++)
			{
				var c = token[i];
				if (PuncRegex().IsMatch(c.ToString()))
				{
					tokens.Add(c.ToString());
				}
				else
				{
					word.Append(c);
					if (i + 1 < token.Length && char.IsPunctuation(token[i + 1]))
					{
						tokens.Add(word.ToString());
						word.Clear();
					}
				}
			}
		}
	}

	private static void HandleContractionsPossessives(IList<string> tokens, string token)
	{
		var r = ContractOrPossessRegex();
		var match = r.Match(token);

		tokens.Add(r.Replace(token, ""));
		tokens.Add(match.ToString());
	}

	private static bool IsContractionOrPossessive(string token)
	{
		return ContractOrPossessRegex().IsMatch(token);
	}

	private static bool IsSpecialException(string token)
	{
		token = token.ToLower();
		return token == "ain't" ||
		       token == "y'all" ||
		       token == "ma'am";
	}

	[GeneratedRegex(@"\bn?'\w\w?", RegexOptions.IgnoreCase)]
	private static partial Regex ContractOrPossessRegex();
	
    [GeneratedRegex(@"(\b\w\.\w\.\w?)|(\b\w{1,3}\.\b)", RegexOptions.IgnoreCase)]
    private static partial Regex AbbrevRegex();
 
    [GeneratedRegex(@"[\p{P}`$\^\|]")]
    private static partial Regex PuncRegex();
 
    [GeneratedRegex(@"\d?\.\d+")]
    private static partial Regex DecimalRegex();
}