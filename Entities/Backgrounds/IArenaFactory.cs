using System;
using System.Collections.Generic;
using FightSaga.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Entities.Backgrounds;

public interface IArenaFactory
{
    IArena CreateArena(List<BackgroundLayer> backgroundLayers);
}
