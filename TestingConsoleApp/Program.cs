namespace TestingConsoleApp;

using DotNLP;

internal class Program
{
	public static void Main()
	{
		var nlp = new DotNLP();
		var test =
			"Let's go to the park today!!! Wouldn't that be nice? I would think so... Dr.Doom will be going. " +
			"But I ain't going! I think Joseph's dog will go though. " +
			"I'm not sure. I live in the U.S.A, which is state-of-the-art!";

		var test2 = "Dr.Doom U.S.A Mr.Blank Mrs.Fields Sr.Almond etc. e.g. a.m. p.m. " +
		            "this is just an ordinary sentence. Wow. " +
		            "I wanna join the U.N.";


		var tokens = nlp.WordTokenize(test2);
		// foreach (var tok in tokens)
		// {
		// 	Console.WriteLine(tok);
		// }
	}
}