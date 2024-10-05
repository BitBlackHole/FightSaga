using System;
using System.Collections.Generic;
using FightSaga.Components;
using FightSaga.Entities.Backgrounds;
using FightSaga.Entities.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightSaga.Core;

public class FightingManager : IFightingManager
{
    private IPlayer player1;
    private IPlayer player2;
    private IArena currentBackgroud;
    private IGraphicsDeviceServiceA graphicsDeviceService;
    private float levelWidth = 5000f;
    private Vector2 cameraPosition;

    public FightingManager(
                        IInputComponentFactory inputComponentFactory,
                        IPlayerFactory playerFactory,
                        IArenaFactory arenaFactory,
                        INamedTextureProvider textureProvider,
                        IGraphicsDeviceServiceA graphicsDeviceService)
    {
        this.graphicsDeviceService = graphicsDeviceService;

        float screenWidth = graphicsDeviceService.Viewport.Width;
        float screenHeight = graphicsDeviceService.Viewport.Height;

        Texture2D player1Texture = textureProvider.GetTexture("PlayerTexture");
        Texture2D player2Texture = textureProvider.GetTexture("PlayerTexture");

        Vector2 player1TextureScale = new Vector2(6.0f, 6.0f);
        Vector2 player2TextureScale = new Vector2(6.0f, 6.0f);

        float maxY = screenHeight - (player1Texture.Height * player1TextureScale.Y) + 400f; // ground level

        // Set ideal start positions for Player 1 and Player 2
        Vector2 player1StartPosition = new Vector2(screenWidth * 0.1f, maxY);    // 10% from the left
        Vector2 player2StartPosition = new Vector2(screenWidth * 0.9f - (player1Texture.Width * player1TextureScale.X), maxY);  // 10% from the right

        Boundary playerBoundary = new Boundary(0, screenWidth, 0, maxY);  // Full screen width for both players

        // Retrieve the InputComponentFactory from DI
        InputComponent inputComponentPlayer1 = inputComponentFactory.CreateForPlayer(1);
        InputComponent inputComponentPlayer2 = inputComponentFactory.CreateForPlayer(2);

        player1 = playerFactory.CreateHumanPlayer(
              player1Texture, // Inject texture
              player1StartPosition,           // Other parameters passed directly
              player1TextureScale,
              SpriteEffects.None,
              inputComponentPlayer1,
              playerBoundary
              );

        player2 = playerFactory.CreateHumanPlayer(
            player2Texture, // Inject texture
            player2StartPosition,           // Other parameters passed directly
            player2TextureScale,
            SpriteEffects.FlipHorizontally,
            inputComponentPlayer2,
            playerBoundary
            );

        var texture1 = textureProvider.GetTexture("ArenaSky");
        var texture2 = textureProvider.GetTexture("ArenaBuilding");
        var texture3 = textureProvider.GetTexture("ArenaYard");
        var texture4 = textureProvider.GetTexture("ArenaGrass");

        var backgroundLayers = new List<BackgroundLayer>
        {
            new (texture1, 0.1f, (float)graphicsDeviceService.Viewport.Width / texture1.Width, (float)graphicsDeviceService.Viewport.Height / texture1.Height),
            new (texture2, 0.3f, (float)graphicsDeviceService.Viewport.Height/ texture2.Width, (float)graphicsDeviceService.Viewport.Height/ texture2.Height),
            new (texture3, 0.6f, (float)graphicsDeviceService.Viewport.Width/ texture3.Width, (float)graphicsDeviceService.Viewport.Height/ texture3.Height),
            new (texture4, 0.8f, (float)graphicsDeviceService.Viewport.Width/ texture4.Width, (float)graphicsDeviceService.Viewport.Height/ texture4.Height)
        };

        // Dynamically calculate the level width based on the widest background layer (scaled)
        float widestLayerWidth = Math.Max(texture1.Width,
                                  Math.Max(texture2.Width,
                                           Math.Max(texture3.Width,
                                                    texture4.Width)));

        levelWidth = widestLayerWidth * (float)graphicsDeviceService.Viewport.Width / widestLayerWidth;

        currentBackgroud = arenaFactory.CreateArena(backgroundLayers);

        // Clamp the camera to prevent it from moving outside the level
        // cameraPosition.X = MathHelper.Clamp(cameraPosition.X, 0, levelWidth - graphicsDeviceService.Viewport.Width / 2);

    }

    public void Update(GameTime gameTime)
    {

        // Calculate the midpoint between the two players
        float midpointX = (player1.Position.X + player2.Position.X) / 2;

        // Center the camera on the midpoint between the players
        cameraPosition = new Vector2(midpointX - graphicsDeviceService.Viewport.Width / 2, 0);

        // Optionally, clamp the camera to the level boundaries
        cameraPosition.X = MathHelper.Clamp(cameraPosition.X, 0, levelWidth - graphicsDeviceService.Viewport.Width);

        currentBackgroud.Update(gameTime, cameraPosition);

        player1.Update(gameTime, player2.Position);
        player2.Update(gameTime, player1.Position);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentBackgroud.Draw(spriteBatch);

        player1.Draw(spriteBatch);
        player2.Draw(spriteBatch);
    }
}
