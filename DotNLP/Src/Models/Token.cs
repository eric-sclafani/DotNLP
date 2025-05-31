namespace DotNLP.Models;

public class Token
{
	private int Id { get; }
	public bool IsSentStart { get; set; }
	public bool IsSentEnd { get; set; }
	
	private readonly Vocab _vocab;

	public Token(Vocab vocab, int id, bool isSentStart=false, bool isSentEnd=false)
	{
		_vocab = vocab;
		IsSentStart = isSentStart;
		IsSentEnd = isSentEnd;
		Id = id;
	}

	public string Text => _vocab[Id];
}