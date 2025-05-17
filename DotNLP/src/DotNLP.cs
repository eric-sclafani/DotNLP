using System.Text;

namespace DotNLP;

public class DotNLP
{
	private const string SPACE = " ";

	public IEnumerable<char> CharTokenize(string text)
	{
		return text.ToCharArray();
	}

	public IEnumerable<string> WordTokenize(string text)
	{
		IList<string> tokens = [];

		var currentWord = new StringBuilder("");

		for (var i = 0; i < text.Length; i++)
		{
			var cString = text[i].ToString();
			if (char.IsPunctuation(text[i]))
			{
				if (currentWord.ToString() != "")
				{
					tokens.Add(currentWord.ToString());
					currentWord.Clear();
				}
				tokens.Add(cString);
			}
			
			else if (cString == SPACE || i == text.Length - 1)
			{
				if (currentWord.ToString() != "")
				{
					tokens.Add(currentWord.ToString());
					currentWord.Clear();
				}
			}
			else
			{
				currentWord.Append(cString);
			}
		}

		return tokens;
	}
}