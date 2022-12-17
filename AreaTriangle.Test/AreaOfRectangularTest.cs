namespace AreaTriangle.Test
{
    public class AreaOfRectangularTest
    {
        [Fact]
        public void CheackRectangularWorksProperly()
        {
            var area = new AreaOfRectangular();
            double result = area.Area(3, 6);
            Assert.Equal(18, result);

        }
        [Fact]
        public void CheckWithInvalidData()
        {
            var area = new AreaOfRectangular();
            double result = area.Area(0, 4);
            Assert.Equal(0, result);

        }
    }
}