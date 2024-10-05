using Microsoft.Xna.Framework;

namespace FightSaga.Core;
public class Boundary
{
    public float MinX { get; private set; }
    public float MaxX { get; private set; }
    public float MinY { get; private set; }
    public float MaxY { get; private set; }

    // Constructor to initialize the boundaries
    public Boundary(float minX, float maxX, float minY, float maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }

    // Method to clamp a position vector within the boundaries
    public Vector2 Clamp(Vector2 position, Vector2 textureSize)
    {
        position.X = MathHelper.Clamp(position.X, MinX, MaxX - textureSize.X);  // Clamp X
        position.Y = MathHelper.Clamp(position.Y, MinY, MaxY - textureSize.Y);  // Clamp Y
        return position;
    }
}
