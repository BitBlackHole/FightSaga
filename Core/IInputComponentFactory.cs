using System;
using FightSaga.Components;

namespace FightSaga.Core;

public interface IInputComponentFactory
{
    InputComponent CreateForPlayer(int playerIndex);
}
