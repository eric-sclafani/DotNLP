
using System.Text;
using System.Text.RegularExpressions;
using DotNLP.Models;

namespace DotNLP.Processing;

public partial class Sentencizer
{
	private readonly Tokenizer _tokenizer;

	public Sentencizer(Tokenizer tokenizer)
	{
		_tokenizer = tokenizer;
	}

	public IList<Sentence> Sentencize(string doc)
	{
		var matches = SentenceRegex().Matches(doc);
		return matches.Select(s => new Sentence(s.ToString(), _tokenizer)).ToList();
	}
	
	[GeneratedRegex(@"[A-Z][^.!?]*(?:\.(?!\s+[A-Z])[^.!?]*)*[.!?]+(?=\s+|$)")]
	private static partial Regex SentenceRegex();
}