namespace AreaTriangle.Test
{
    public class AreaOfCircleTest
    {
        [Fact]
        public void CheackTriangleWorksProperly()
        {
            double radius = 12;
            var area = new AreaOfCircle();
            double result = area.Area(radius);
            Assert.Equal(Math.PI * radius * radius, result);
        }
    }
}