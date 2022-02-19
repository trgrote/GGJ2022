using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyInsideHandler : InsideTriggerHandler
{
    [SerializeField] BabyState _babyState;

    public override void SetInside(bool isInside) => _babyState._isInside = isInside;
}
