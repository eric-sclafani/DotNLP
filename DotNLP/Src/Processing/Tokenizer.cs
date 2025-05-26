using System.Text;
using System.Text.RegularExpressions;
using DotNLP.Models;

namespace DotNLP.Processing;

public partial class Tokenizer
{
	private readonly Vocab _vocab;

	public Tokenizer(Vocab vocab)
	{
		_vocab = vocab;
	}

	public IList<Token> Tokenize(string text)
	{
		IList<string> textSplit = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		IList<Token> tokens = [];

		foreach (var token in textSplit)
		{
			IList<string> innerTokens = [];
			if (ContractOrPossessRegex().IsMatch(token) && !IsSpecialException((token)))
			{
				innerTokens = HandleContractionsPossessives(token);
			}

			else if (PuncRegex().IsMatch(token) && !IsSpecialException((token)))
			{
				innerTokens = HandlePunctuation(token);
			}
			else
			{
				innerTokens.Add(token);
			}

			foreach (var innerToken in innerTokens)
			{
				var id = _vocab.TryAddtoken(innerToken);
				tokens.Add(new Token(_vocab, id));
			}
		}

		return tokens;
	}

	private static IList<string> HandlePunctuation(string token)
	{
		IList<string> tokens = [];
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

		return tokens;
	}

	private static IList<string> HandleContractionsPossessives(string token)
	{
		IList<string> tokens = [];
		var r = ContractOrPossessRegex();
		var match = r.Match(token);

		tokens.Add(r.Replace(token, ""));
		tokens.Add(match.ToString());
		return tokens;
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