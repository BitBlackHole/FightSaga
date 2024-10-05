using System;
using System.Collections.Generic;
using System.Linq;
using FightSaga.Core;
using FightSaga.Entities.Backgrounds;
using FightSaga.Entities.Players;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightSaga;

public class MainGame : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private IServiceProvider serviceProvider;
    private IFightingManager fightingManager;

    private const int DESIGNED_RESOULTION_WIDTH = 2560;
    private const int DESIGNED_RESOULTION_HEIGHT = 1600;
    public MainGame()
    {
        graphics = new GraphicsDeviceManager(this);

        graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    private void ConfigureServices(ServiceCollection services)
    {
        // Register the SpriteBatch (as before)
        services.AddSingleton<SpriteBatch>(provider => new SpriteBatch(GraphicsDevice));

        // Register GraphicsDeviceService and pass the current GraphicsDevice
        services.AddSingleton<IGraphicsDeviceServiceA>(provider => new GraphicsDeviceService(GraphicsDevice));

        var textures = LoadAllTextures();

        services.AddSingleton<INamedTextureProvider>(provider => new NamedTextureProvider(textures));

        // Register the InputComponent factory
        services.AddSingleton<IInputComponentFactory, InputComponentFactory>();

        services.AddSingleton<IPlayerFactory, PlayerFactory>();

        services.AddSingleton<IArenaFactory, ArenaFactory>();

        services.AddSingleton<IFightingManager, FightingManager>();
    }

    private Dictionary<string, Texture2D> LoadAllTextures()
    {
        return new Dictionary<string, Texture2D>
        {
            { "PlayerTexture", Content.Load<Texture2D>("ssf2t110") },
            { "ArenaTexture", Content.Load<Texture2D>("CityArena") },
            { "ArenaSky", Content.Load<Texture2D>("ss_0002_sky") },
            { "ArenaBuilding", Content.Load<Texture2D>("ss_0001_structure") },
            { "ArenaYard", Content.Load<Texture2D>("ss_0003_yard") },
            { "ArenaGrass", Content.Load<Texture2D>("ss_0000_grass") }
        };
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = DESIGNED_RESOULTION_WIDTH;
        graphics.PreferredBackBufferHeight = DESIGNED_RESOULTION_HEIGHT;
        graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        var services = new ServiceCollection();
        ConfigureServices(services);
        serviceProvider = services.BuildServiceProvider();

        fightingManager = serviceProvider.GetRequiredService<IFightingManager>();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        fightingManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
        fightingManager.Draw(spriteBatch);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
