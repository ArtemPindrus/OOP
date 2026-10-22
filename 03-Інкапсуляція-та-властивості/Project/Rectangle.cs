namespace Project;

public class Rectangle {
    public Rectangle(float width, float height) {
        Width = width;
        Height = height;
    }

    public float Width {
        get;
        set {
            if (value < 0) throw new ArgumentException("Width should be positive.");

            field = value;
        }
    }
    public float Height {
        get;
        set {
            if (value < 0) throw new ArgumentException("Height should be positive.");

            field = value;
        }
    }

    public float Area => Width * Height;

    public float Perimeter => Width * 2 + Height * 2;
}