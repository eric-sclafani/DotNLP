namespace TestingConsoleApp;

using DotNLP;

internal class Program
{
	public static void Main()
	{
		var nlp = new DotNLP();
		var test =
			"Let's go to the park today!!! I would think so... !!!He?? ...will!! be going. " +
			"But I ain't going! I think Joseph's dog will go though. Or will he... Dr.Doom is in the U.S.A " +
			"and later on, the U.N. It is really state-of-the-art. Mrs.Fields says so, after all.";
		
		var tokens = nlp.WordTokenize(test);
		foreach (var tok in tokens)
		{
			Console.WriteLine(tok);
		}
	}
}