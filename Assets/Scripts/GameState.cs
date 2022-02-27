using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eGameState
{
    GAMEMODE
}

[CreateAssetMenu(menuName = "GGJ2022/Game State")]
public class GameState : ScriptableObject
{
    protected eGameState _state;

    public event Action<eGameState> OnStateChanged;

    public eGameState State
    {
        get => _state;
        set
        {
            _state = value;
            OnStateChanged?.Invoke(_state);
        }
    }
}
