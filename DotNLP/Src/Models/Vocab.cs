using System.Text.Json;

namespace DotNLP.Models;

public class Vocab
{
	private readonly Dictionary<int,string> _idTokenDict = new();
	private readonly Dictionary<string, int> _tokenIdDict = new();
	private int _globalId = 0;

	public override string ToString()
	{
		return JsonSerializer.Serialize(_idTokenDict);
	}
	
	public string this[int key] => 
		_idTokenDict.TryGetValue(key, out var value) ? value : default!;

	public int TryAddtoken(string token)
	{
		int id;
		if (IsNewToken(token))
		{
			_idTokenDict[_globalId] = token;
			_tokenIdDict[token] = _globalId;
			id = _globalId;
			_globalId++;
		}
		else
		{
			id = _tokenIdDict[token];
		}
		return id;
	}
	
	private bool IsNewToken(string value)
	{
		return !_idTokenDict.ContainsValue(value.ToLower());
	}
}