using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArmsWhenHolding : MonoBehaviour
{
    [SerializeField] DogState _state;
    [SerializeField] float _downRotation = 90f;
    [SerializeField] float _upRotation = 180f;

    // Update is called once per frame
    void Update()
    {
        if (_state._mode == DogStateMode.HOLDING)        
        {
            transform.localRotation = Quaternion.Euler(_upRotation, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(_downRotation, 0, 0);
        }
    }
}
