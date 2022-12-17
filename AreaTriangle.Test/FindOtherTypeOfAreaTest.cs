namespace AreaTriangle.Test
{
    public class FindOtherTypeOfAreaTest
    {
        [Fact]
        public void Test1()
        {
            var area = new FindOtherTypeOfArea();
            double result = area.Area(4,2);
            Assert.Equal(4, Math.Round(result));
        }
    }
}