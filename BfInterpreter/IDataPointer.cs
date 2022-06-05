namespace BfInterpreter;

public interface IDataPointer
{
    int[] DataArray { get; }
    uint Position { get; set; }
    int Value { get; set; }

    void DecrementPosition();
    void DecrementValue();
    void IncrementPosition();
    void IncrementValue();
}