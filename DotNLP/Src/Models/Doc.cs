using DotNLP.Processing;

namespace DotNLP.Models;


public class Doc
{
	private readonly Vocab _vocab;
	private string _text { get; }
	
	public IList<Token> Tokens { get; private set; }

	public Doc(string text, Vocab vocab)
	{
		_text = text;
		_vocab = vocab;
		Tokens = InitTokens();
	}

	private IList<Token> InitTokens()
	{
		var tokenizer = new Tokenizer(_vocab);
		return tokenizer.Tokenize(_text);
	}

	public override string ToString()
	{
		return _text;
	}
	
	
	
}