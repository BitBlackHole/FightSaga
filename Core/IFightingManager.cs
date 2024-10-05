using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Core;

public interface IFightingManager
{
    void Update(GameTime gameTime);

    void Draw(SpriteBatch spriteBatch);
}
