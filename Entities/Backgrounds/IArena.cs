using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Entities.Backgrounds;

public interface IArena
{
    void Update(GameTime gameTime, Vector2 cameraPosition);

    void Draw(SpriteBatch spriteBatch);
}
