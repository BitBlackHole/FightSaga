using System;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Entities.Backgrounds;

public class BackgroundLayer
{
    public Texture2D Texture { get; private set; }
    public float ParallaxFactor { get; private set; }  // Determines the speed of this layer relative to camera
    public Vector2 Position { get; private set; }

    public float scaleX, scaleY;

    public BackgroundLayer(Texture2D texture, float parallaxFactor, float scaleX, float scaleY)
    {
        Texture = texture;
        ParallaxFactor = parallaxFactor;
        Position = Vector2.Zero;  // Initial position
        this.scaleX = scaleX;
        this.scaleY = scaleY;
    }

    public void Update(Vector2 cameraPosition)
    {
        // Update the position of this layer based on the camera's position and the parallax factor
        Position = new Vector2(cameraPosition.X * ParallaxFactor, 0);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, new Vector2(scaleX, scaleY), SpriteEffects.None, 0f);
    }
}
