using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace FightSaga.Core;

public class NamedTextureProvider : INamedTextureProvider
{
    private readonly IDictionary<string, Texture2D> textures;

    public NamedTextureProvider(IDictionary<string, Texture2D> textures)
    {
        this.textures = textures;
    }

    public Texture2D GetTexture(string name)
    {
        if (textures.TryGetValue(name, out var texture))
        {
            return texture;
        }
        throw new ArgumentException($"Texture '{name}' not found.");
    }
}
