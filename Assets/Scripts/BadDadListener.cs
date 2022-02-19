using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDadListener : MonoBehaviour
{
    [SerializeField] DogState _dogState;
    [SerializeField] float _poopInsideValue = 0.1f;

    // Update is called once per frame
    public void OnPoop()
    {
        _dogState._badBadMeter += _poopInsideValue;
    }
}
