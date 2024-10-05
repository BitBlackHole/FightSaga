using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Entities.Players;

public interface IPlayer
{
    Vector2 Position { get; }
    void Update(GameTime gameTime, Vector2 opponentPosition);

    void Draw(SpriteBatch spriteBatch);
}
