using FightSaga.Components;
using FightSaga.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightSaga.Entities.Players;

public class PlayerFactory : IPlayerFactory
{
    public IPlayer CreateHumanPlayer(Texture2D texture, Vector2 startPosition, Vector2 textureScale, SpriteEffects spriteEffects, InputComponent inputComponent, Boundary boundary)
    {
        return new HumanPlayer(texture, startPosition, textureScale, spriteEffects, inputComponent, boundary);
    }
}
