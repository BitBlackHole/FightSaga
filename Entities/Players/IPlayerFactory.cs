using FightSaga.Components;
using FightSaga.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightSaga.Entities.Players;

public interface IPlayerFactory
{
    IPlayer CreateHumanPlayer(Texture2D texture, Vector2 startPosition, Vector2 textureScale, SpriteEffects spriteEffects, InputComponent inputComponent, Boundary boundary);
}
