namespace TestingConsoleApp;

using DotNLP;

internal class Program
{
	public static void Main()
	{
		IEnumerable<string> docs= [
			"This is also a testing string... It's nice and good! I am happy. Aren't you? I'm sad. He didn't...",
			"I'm not sure... Mrs.Thistle will come back to the U.S.A soon I hope."
		];
		
		var nlp = new DotNLP(docs);
		var d = nlp.Docs[0];
		foreach (var tok in d.Tokens)
		{
			Console.WriteLine(tok.Text);
		}
	}
}