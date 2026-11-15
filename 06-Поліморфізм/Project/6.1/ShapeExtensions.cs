namespace Project;

public static class ShapeExtensions {
    extension(IEnumerable<Shape> shapes) {
        public double TotalArea() => shapes.Aggregate(0.0, (acc, s) => acc + s.Area());

        public IEnumerable<Shape> OrderByArea() => shapes.OrderBy(x => x.Area());

        public Shape Largest() => shapes.MaxBy(x => x.Area());
    }
}