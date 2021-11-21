namespace SpatialQuery.Domain.Shapes
{
	public struct Point : IPoint
	{
		public Point(double coordinateX, double coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public double Area => 0;

        public IPoint Center => this;

        public double Length => 0;

        public double CoordinateX { get; }
        public double CoordinateY { get; }

        public override string ToString() => $"Point ({CoordinateX}, {CoordinateY})";
    }
}
