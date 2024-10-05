using System;
using FightSaga.Components.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Components;

public class AnimationComponent : IAnimationComponent
{
    private Texture2D spriteSheet;
    private int frameWidth, frameHeight;
    private int currentFrame;
    private int totalFrames;
    private int animationRow;
    private float timePerFrame;
    private float timer;

    public void SetAnimation(string animationName)
    {
        throw new NotImplementedException();
    }

    public void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
    }

}
