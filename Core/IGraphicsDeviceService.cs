using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Core;

public interface IGraphicsDeviceServiceA
{
    GraphicsDevice GraphicsDevice { get; }
    Viewport Viewport { get; }
}
