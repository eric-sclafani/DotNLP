namespace DotNLP.Models;

public class Token
{
	public int Id { get; }
	private readonly Vocab _vocab;

	public Token(Vocab vocab, int id)
	{
		_vocab = vocab;
		Id = id;
	}

	public string Text()
	{
		return _vocab[Id];
	}
}