using static DotNLP.Tokenizer.Tokenizer;

namespace DotNLP.Models;

public class Doc
{
	public string Text { get; }

	public Doc(string text)
	{
		Text = text;
	}

	public IEnumerable<string> Tokens()
	{
		return WordTokenize(Text);
	}
}