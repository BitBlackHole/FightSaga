using System;
using FightSaga.Components;
using Microsoft.Xna.Framework.Input;

namespace FightSaga.Core;

public class InputComponentFactory : IInputComponentFactory
{
    public InputComponent CreateForPlayer(int playerIndex)
    {
        if (playerIndex == 1)
        {
            // InputComponent for Player 1
            return new InputComponent(200f, [Keys.A, Keys.D, Keys.W, Keys.S]);
        }
        else if (playerIndex == 2)
        {
            // InputComponent for Player 2
            return new InputComponent(200f, [Keys.Left, Keys.Right, Keys.Up, Keys.Down]);
        }
        else
        {
            throw new ArgumentException("Invalid player index.");
        }
    }
}
