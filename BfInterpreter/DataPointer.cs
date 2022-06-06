namespace BfInterpreter;

public class DataPointer : IDataPointer
{
    public const int InitialArrayLength = 100;
    public const int ArrayLengthFactor = 5;

    private uint length;
    private uint position;
    private readonly bool fixedSize = false;

    public DataPointer(uint position = 0, uint length = InitialArrayLength, int[]? dataArray = null)
    {
        this.fixedSize = length != InitialArrayLength;
        this.length = length;
        Position = position;
        DataArray = dataArray ?? new int[this.length];
    }

    public uint Position 
    { 
        get {
            return this.position;
        }
        set {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            if (value >= length)
            {
                this.ExtendArray(value);
            }
            this.position = value;
        } 
    }
    
    public int Value { get => this.DataArray[this.Position]; set => this.DataArray[this.Position] = value; }

    public int[] DataArray { get; private set; }

    public void IncrementPosition()
    {
        this.Position++;
    }

    public void DecrementPosition()
    {
        this.Position--;
    }

    public void IncrementValue()
    {
        this.Value++;
    }

    public void DecrementValue()
    {
        this.Value--;
    }

    private void ExtendArray(uint minimumLength)
    {
        if (this.fixedSize)
        {
            throw new InvalidOperationException("Index out of bounds for fixed Array size");
        }

        while(this.length <= minimumLength)
        {
            this.length *= ArrayLengthFactor;
        }

        var newArray = new int[length];
        Array.Copy(this.DataArray, newArray, this.DataArray.Length);
        this.DataArray = newArray;
    }
}
