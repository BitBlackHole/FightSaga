using System.Collections.Generic;
using FightSaga.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Entities.Backgrounds;

public class CityArena : IArena
{
    private List<BackgroundLayer> backgroundLayers;

    public CityArena(List<BackgroundLayer> backgroundLayers)
    {
        this.backgroundLayers = backgroundLayers;

    }

    public void Update(GameTime gameTime, Vector2 cameraPosition)
    {
        // //Debug.WriteLine("CityArena Updated!!");
        // KeyboardState state = Keyboard.GetState();
        // if (state.IsKeyDown(Keys.Left)) cameraPosition.X -= 5;
        // if (state.IsKeyDown(Keys.Right)) cameraPosition.X += 5;

        backgroundLayers.ForEach(backgroundLayer => backgroundLayer.Update(cameraPosition));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        //Debug.WriteLine("CityArena Drawn!!");
        //spriteBatch.Draw(backgroundTexture, rectangle, Color.White);
        // spriteBatch.Draw(backgroundLayer1, new Vector2(cameraPosition.X * 0.1f, 0), Color.White);
        // spriteBatch.Draw(backgroundLayer2, new Vector2(cameraPosition.X * 0.3f, 0), Color.White);
        // spriteBatch.Draw(backgroundLayer3, new Vector2(cameraPosition.X * 0.6f, 0), Color.White);
        // spriteBatch.Draw(backgroundLayer4, new Vector2(cameraPosition.X * 0.8f, 0), Color.White);

        backgroundLayers.ForEach(backgroundLayer => backgroundLayer.Draw(spriteBatch));
    }
}

