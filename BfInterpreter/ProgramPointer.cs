namespace BfInterpreter;

internal class ProgramPointer
{
    private readonly Stack<int> stack = new();
    private readonly string program;

    public ProgramPointer(string program)
    {
        this.program = program;
    }

    public int Position { get; private set; } = 0;
    public char Current { get => this.program[this.Position]; }

    public void JumpBack()
    {
        int i = -1;
        while (i < 0)
        {
            this.Dec();
            if (this.Current == '[')
            {
                i++;
            }
            else if (this.Current == ']')
            {
                i--;
            }
        }
        this.Inc();
    }

    public bool JumpForwards()
    {
        int i = 1;
        while(i > 0)
        {
            this.Inc();
            if (this.Current == '[')
            {
                i++;
            }
            else if (this.Current == ']')
            {
                i--;
            }
        }
        return this.Inc();
    }

    public bool Inc()
    {
        this.Position++;
        return this.Position == this.program.Length;
    }

    private void Dec()
    {
        this.Position--;
    }
}
