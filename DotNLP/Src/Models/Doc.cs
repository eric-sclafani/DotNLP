using static DotNLP.Tokenizer.Tokenizer;

namespace DotNLP.Models;



public class Doc
{
	private string Text { get; }

	public Doc(string text)
	{
		Text = text;
	}

	public override string ToString()
	{
		return Text;
	}

	public IList<string> Tokens()
	{
		return WordTokenize(Text);
	}

	// public List<string[]> NGrams(int n = 2)
	// {
	// 	var tokens = Tokens();
	// 	List<string[]> ngrams = [];
	// 	for (var i = 0; i < tokens.Count-1; i++)
	// 	{
	// 		
	// 	}
	// 	
	// 	
	// }
}