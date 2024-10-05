using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Core;

public class GraphicsDeviceService : IGraphicsDeviceServiceA
{
    private readonly GraphicsDevice graphicsDevice;

    public GraphicsDeviceService(GraphicsDevice graphicsDevice)
    {
        this.graphicsDevice = graphicsDevice;
    }

    public GraphicsDevice GraphicsDevice => graphicsDevice;

    public Viewport Viewport => graphicsDevice.Viewport;
}
