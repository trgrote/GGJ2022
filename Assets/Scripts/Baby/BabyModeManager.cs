using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyModeManager : MonoBehaviour
{
    [SerializeField] BabyState _state;

    [SerializeField] List<Behaviour> _groundBehaviors = new List<Behaviour>();

    void Start()
    {
        _state._mode = BabyStateMode.ON_GROUND;
    }

    [NaughtyAttributes.Button]
    public void Pickup()
    {
        _state._mode = BabyStateMode.HELD;
        _groundBehaviors.ForEach(b => b.enabled = false);
    }

    [NaughtyAttributes.Button]
    public void Drop()
    {
        _state._mode = BabyStateMode.ON_GROUND;
        _groundBehaviors.ForEach(b => b.enabled = true);
    }
}
