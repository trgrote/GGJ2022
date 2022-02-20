using System;
using UnityEngine;

public enum BabyStateMode
{
    ON_GROUND,
    HELD
}

[CreateAssetMenu(menuName = "GGJ2022/Baby State")]
public class BabyState : ScriptableObject
{
    public const float MAX = 1f;
    public float _potty;
    public float _boredom;
    public IBabyAction _currentAction;
    public BabyStateMode _mode = BabyStateMode.ON_GROUND;
    protected bool _isInside;
    public event Action OnIsInsideChanged;
    public bool isInside
    {
        get => _isInside;
        set
        {
            _isInside = value;
            OnIsInsideChanged?.Invoke();
        }
    }
}
