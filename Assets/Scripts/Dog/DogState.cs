using System;
using UnityEngine;

public enum DogStateMode
{
    WALKING,
    WORKING,
    HOLDING
}

[CreateAssetMenu(menuName = "GGJ2022/Dog State")]
public class DogState : ScriptableObject
{
    public Vector3 _currentMovement = Vector3.zero;

    public float _badBadMeter = 0f;  // 0 -> 1f
    public float _workMeter = 0f;   // 0 -> 1f

    public DogStateMode _mode = DogStateMode.WALKING;
    
    public int _workMultiplier = 1;
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
