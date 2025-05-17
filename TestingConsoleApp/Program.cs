namespace TestingConsoleApp;

using DotNLP;

internal class Program
{
	public static void Main()
	{
		var nlp = new DotNLP();
		var test1 = "This is my sentence. It's a good and amazing sentence.";
		var test2 = "This is my sentence with consecutive punctuation!!. It's a good and amazing sentence.";
		var test3 = "Let's go to the park today!!! Wouldn't that be nice? I would think so...";
		var tokens = nlp.WordTokenize(test3);
		foreach (var tok in tokens)
		{
			Console.WriteLine(tok);
		}
	}
}