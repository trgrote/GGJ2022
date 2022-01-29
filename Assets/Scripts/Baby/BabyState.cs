using UnityEngine;

[CreateAssetMenu(menuName = "GGJ2022/Baby State")]
public class BabyState : ScriptableObject
{
    public const float MAX = 1f;
    public float _potty;
    public float _boredom;
    public IBabyAction _currentAction;
}
