namespace ToDoBlazor.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const int expected = 1;
            const int actual = 2;

            Assert.Equal(expected, actual);
        }
    }
}