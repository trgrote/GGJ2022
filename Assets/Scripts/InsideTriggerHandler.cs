using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InsideTriggerHandler : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _insideTriggers;

    public abstract void SetInside(bool isInside);

    void OnTriggerEnter(Collider collider)
    {
        if (_insideTriggers.Contains(collider.gameObject))
        {
            SetInside(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (_insideTriggers.Contains(collider.gameObject))
        {
            SetInside(false);
        }
    }
}
