using System.Reflection.Metadata.Ecma335;
using FightSaga.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Entities.Players;

public class AIPlayer : IPlayer
{
    private Texture2D texture;
    private Vector2 position;
    private Vector2 textureScale;
    private HealthComponent healthComponent;

    private IAIComponent aiComponent;
    private SpriteEffects spriteEffects;

    public Vector2 Position { get => position; }


    public AIPlayer(Texture2D texture, Vector2 startPosition, Vector2 textureScale, SpriteEffects spriteEffects)
    {
        this.texture = texture;
        this.position = startPosition;
        this.textureScale = textureScale;
        this.spriteEffects = spriteEffects;
        this.aiComponent = null;
        healthComponent = new HealthComponent();
    }

    public void Update(GameTime gameTime, Vector2 opponentPosition)
    {
        // position = inputComponent.GetMovement(position, gameTime);
        // Debug.WriteLine("HumanPlayer Postion Updated: " + position.ToString());
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, textureScale, spriteEffects, 0f);
        // Debug.WriteLine("HumanPlayer Drawn!!");
    }
}
