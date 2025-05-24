namespace TestingConsoleApp;

using DotNLP;

internal class Program
{
	public static void Main()
	{
		IEnumerable<string> docs= [
			"Hello!! This is testing string #1! How'd you do?"
		];
		
		var nlp = new DotNLP(docs);
		
		
		
	}
}