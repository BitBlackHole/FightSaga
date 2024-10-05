using System;
using System.Collections.Generic;
using FightSaga.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Entities.Backgrounds;

public class ArenaFactory : IArenaFactory
{
    public IArena CreateArena(List<BackgroundLayer> backgroundLayers)
    {
        return new CityArena(backgroundLayers);
    }
}
