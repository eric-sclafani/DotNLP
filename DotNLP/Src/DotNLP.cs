

using DotNLP.Models;

namespace DotNLP;

public class DotNLP
{
	public IList<Doc> Docs { get; private set; }

	public DotNLP(IEnumerable<string> docs)
	{
		Docs = ProcessDocuments(docs);
	}

	private static List<Doc> ProcessDocuments(IEnumerable<string> docs)
	{
		return docs.Select(d => new Doc(d)).ToList();
	}
	
	
	
	
	
	
}