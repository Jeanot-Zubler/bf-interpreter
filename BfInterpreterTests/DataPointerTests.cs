namespace BfInterpreter.Tests;

[TestClass()]
public class DataPointerTests
{
    [TestMethod()]
    public void IncrementValueTest()
    {
        var expected = 1;

        DataPointer pointer = new();
        pointer.IncrementValue();
        var actual = pointer.DataArray[0];

        Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void DecrementValueTest()
    {
        var expected = -1;

        DataPointer pointer = new();
        pointer.DecrementValue();
        var actual = pointer.DataArray[0];

        Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void IncrementPosition_pastArrayBoundaries()
    {
        DataPointer pointer = new();
        int max = DataPointer.InitialArrayLength;
        for (int i = 0; i < max + 10; i++)
        {
            pointer.IncrementPosition();
        }
        Assert.IsTrue(pointer.DataArray.Length > max);
    }
}