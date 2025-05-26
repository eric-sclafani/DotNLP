

using DotNLP.Models;

namespace DotNLP;

public class DotNLP
{
	public IList<Doc> Docs { get; private set; }
	public Vocab Vocab { get; private set; }

	public DotNLP(IEnumerable<string> docs)
	{
		Vocab = new Vocab();
		Docs = ProcessDocuments(docs);
	}
	 
	private List<Doc> ProcessDocuments(IEnumerable<string> docs)
	{
		return docs.Select(d => new Doc(d, Vocab)).ToList();
	}
	
	
	
	
	
	
}