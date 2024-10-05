using System.Diagnostics;
using FightSaga.Components;
using FightSaga.Components.Interfaces;
using FightSaga.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightSaga.Entities.Players;

public class HumanPlayer : IPlayer
{
    private Texture2D texture;
    private Vector2 position;
    public Vector2 Position { get => position; }

    private Vector2 textureScale;

    private SpriteEffects spriteEffects;

    private InputComponent inputComponent;
    private HealthComponent healthComponent;

    private IAnimationComponent animationComponent;

    private Boundary movementBoundary;

    public HumanPlayer(Texture2D texture, Vector2 startPosition, Vector2 textureScale, SpriteEffects spriteEffects, InputComponent inputComponent, Boundary boundary)
    {

        this.texture = texture;
        this.position = startPosition;
        this.textureScale = textureScale;
        this.spriteEffects = spriteEffects;
        this.inputComponent = inputComponent;//new InputComponent(200f, keySet);
        healthComponent = new HealthComponent();
        animationComponent = new SpriteSheetAnimationComponent();
        this.movementBoundary = boundary;
    }

    public void Update(GameTime gameTime, Vector2 opponentPosition)
    {
        position = inputComponent.GetMovement(position, gameTime);

        position = movementBoundary.Clamp(position, texture.Bounds.Size.ToVector2() * textureScale);

        if (position.X < opponentPosition.X && spriteEffects != SpriteEffects.None)
        {
            spriteEffects = SpriteEffects.None;
        }
        else if (position.X > opponentPosition.X && spriteEffects != SpriteEffects.FlipHorizontally)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }

        Debug.WriteLine("HumanPlayer Postion Updated: " + position.ToString());
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, textureScale, spriteEffects, 0f);
        // Debug.WriteLine("HumanPlayer Drawn!!");
    }
}
