using DotNLP.Models;
using DotNLP.Processing;

namespace DotNLP;

public class DotNLP
{
	public IList<Doc> Docs { get; private set; }
	public Vocab Vocab { get; private set; }

	private readonly Tokenizer _tokenizer;
	private readonly Sentencizer _sentencizer;

	public DotNLP(IEnumerable<string> docs)
	{
		Vocab = new Vocab();
		_tokenizer = new Tokenizer(Vocab);
		_sentencizer = new Sentencizer(_tokenizer);
		
		Docs = ProcessDocuments(docs);
	}
	 
	private List<Doc> ProcessDocuments(IEnumerable<string> docs)
	{
		return docs.Select(
			d => new Doc(d, _tokenizer, _sentencizer)
			).ToList();
	}
	
	
	
	
	
	
}