namespace TestingConsoleApp;

using DotNLP;

internal class Program
{
	public static void Main()
	{
		IEnumerable<string> docs= [
			"This is test string number one...",
			"I'm not sure... Mrs.Thistle will come back to the U.S.A soon I hope."
		];
		
		var nlp = new DotNLP(docs);
		
		



	}
}