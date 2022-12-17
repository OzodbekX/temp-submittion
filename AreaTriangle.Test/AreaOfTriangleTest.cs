namespace AreaTriangle.Test
{
    public class AreaOfTriangleTest
    {
        [Fact]
        public void CheackTriangleWorksProperly()
        {
            var area = new AreaOfTriangle();
            double result = area.Area(3, 5, 4);
            Assert.Equal(6, result);

        }
        [Fact]
        public void CheckWithInvalidData()
        {
            var area = new AreaOfTriangle();
            double result = area.Area(1, 2, 4);
            Assert.Equal(0, result);

        }
        [Fact]
        public void CheckIsThisRectangularTriangle()
        {
            var area = new AreaOfTriangle();
            bool result = area.IsThisRectangularTriangle(3, 5, 4);
            Assert.Equal(true, result);

        }
        [Fact]
        public void CheckIsThisRectangularTriangleForFalse()
        {
            var area = new AreaOfTriangle();
            bool result = area.IsThisRectangularTriangle(3, 2, 4);
            Assert.Equal(false, result);

        }
    }
}