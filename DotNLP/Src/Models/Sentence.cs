using DotNLP.Processing;

namespace DotNLP.Models;

public class Sentence
{
	private readonly Tokenizer _tokenizer;
	private readonly string _text;
	public IList<Token> Tokens { get; private set; }

	public Sentence(string text, Tokenizer tokenizer)
	{
		_tokenizer = tokenizer;
		_text = text;
		Tokens = InitTokens();
	}

	public override string ToString()
	{
		return _text;
	}

	private IList<Token> InitTokens()
	{
		var tokens = _tokenizer.Tokenize(_text);
		for (var i=0; i < tokens.Count; i++)
		{
			var tok = tokens[i];
			if (i == 0)
			{
				tok.IsSentStart = true;
			}
			else if (i + 1 == tokens.Count)
			{
				tok.IsSentEnd = true;
			}
		}

		return tokens;

	}
}