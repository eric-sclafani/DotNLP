namespace TestingConsoleApp;

using DotNLP;

internal class Program
{
	public static void Main()
	{
		IEnumerable<string> docs= [
			"Hello!! This is testing string #1! How'd you do?",
			"I'm not sure... Mrs.Thistle will come back to the U.S.A soon I hope."
		];
		
		var nlp = new DotNLP(docs);

		var d1 = nlp.Docs[0];
		
		

	}
}