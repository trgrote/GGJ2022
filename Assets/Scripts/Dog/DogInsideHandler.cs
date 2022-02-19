using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInsideHandler : InsideTriggerHandler
{
    [SerializeField] DogState _dogState;

    public override void SetInside(bool isInside) => _dogState._isInside = isInside;
}
