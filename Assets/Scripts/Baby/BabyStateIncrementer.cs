using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyStateIncrementer : MonoBehaviour
{
    [SerializeField] BabyState _state;

    [SerializeField] float _pottyRate = 0.1f;
    [SerializeField] float _boredomRate = 0.2f;

    const float _stateMax = 100f;

    // Update is called once per frame
    void Update()
    {
        _state._potty = Mathf.Min(_state._potty + _pottyRate * Time.deltaTime, _stateMax);
        _state._boredom = Mathf.Min(_state._boredom + _boredomRate * Time.deltaTime, _stateMax);
    }
}
