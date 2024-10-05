using System;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Core;

public interface INamedTextureProvider
{
    Texture2D GetTexture(string name);
}
