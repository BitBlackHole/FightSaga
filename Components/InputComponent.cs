using FightSaga.Entities.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FightSaga.Components;


public class InputComponent
{
    private float playerSpeed;
    private Keys[] keySet;

    public InputComponent(float playerSpeed, Keys[] keySet)
    {
        this.playerSpeed = playerSpeed;
        this.keySet = keySet;
    }

    public Vector2 GetMovement(Vector2 initialPosition, GameTime gameTime)
    {
        var movement = initialPosition;

        var movementPerFrame = playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        var state = Keyboard.GetState();

        if (state.IsKeyDown(keySet[0]))
        {
            movement.X -= movementPerFrame;
        }
        if (state.IsKeyDown(keySet[1]))
        {
            movement.X += movementPerFrame;
        }
        if (state.IsKeyDown(keySet[2]))
        {
            movement.Y -= movementPerFrame;
        }
        if (state.IsKeyDown(keySet[3]))
        {
            movement.Y += movementPerFrame;
        }

        return movement;
    }

}



