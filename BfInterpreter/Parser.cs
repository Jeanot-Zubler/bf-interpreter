namespace BfInterpreter;

public class Parser
{
    IEnumerable<char> ValidChars;

    public Parser(IEnumerable<char> validChars)
    {
        ValidChars = validChars;
    }

    public string Strip(string code)
    {
        return new string(code.Where(c=>this.ValidChars.Contains(c)).ToArray());
    }
}