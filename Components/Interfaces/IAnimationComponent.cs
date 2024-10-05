using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Components.Interfaces;

public interface IAnimationComponent
{
    void SetAnimation(string animationName);
    void Update(GameTime gameTime);

    void Draw(SpriteBatch spriteBatch);

}
