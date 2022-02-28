using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eGameState
{
    TITLE,
    GAMEMODE
}

[CreateAssetMenu(menuName = "GGJ2022/Game State")]
public class GameState : rho.ExternalVariable<eGameState>
{
}
