using DotNLP.Processing;

namespace DotNLP.Models;

public class Doc
{
	private string _text { get; }
	private readonly Tokenizer _tokenizer;
	private readonly Sentencizer _sentencizer;
	
	public IList<Sentence> Sentences { get; private set; }
	public IList<Token> Tokens { get; private set; }

	public Doc(string text, Tokenizer tokenizer, Sentencizer sentencizer)
	{
		_text = text;
		_tokenizer = tokenizer;
		_sentencizer = sentencizer;
		
		Sentences = InitSentences();
		Tokens = InitTokens();
	}

	private IList<Sentence> InitSentences()
	{
		return _sentencizer.Sentencize(_text);
	}

	private List<Token> InitTokens()
	{
		List<Token> tokens = [];
		foreach (var s in Sentences)
		{
			tokens.AddRange(s.Tokens);
		}
		return tokens;
	}

	public override string ToString()
	{
		return _text;
	}
	
	
	
}