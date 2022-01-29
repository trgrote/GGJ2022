using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyStateIncrementer : MonoBehaviour
{
    [SerializeField] BabyState _state;

    float _pottyRate = 0.05f;
    float _boredomRate = 0.08f;

    // Update is called once per frame
    void Update()
    {
        _state._potty = Mathf.Min(_state._potty + _pottyRate * Time.deltaTime, BabyState.MAX);
        _state._boredom = Mathf.Min(_state._boredom + _boredomRate * Time.deltaTime, BabyState.MAX);
    }
}
