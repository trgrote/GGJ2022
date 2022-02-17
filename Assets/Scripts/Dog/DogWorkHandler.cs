using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWorkHandler : MonoBehaviour
{
    [SerializeField] DogState _state;

    float _workRate = 0.001f;
    float _workRateInterval = 3f;

    IEnumerator Work()
    {
        _state._workMultiplier = 1;

        var elapsedTime = 0f;
        
        while (true)
        {
            if (elapsedTime > _workRateInterval)
            {
                _state._workMultiplier++;
                elapsedTime = elapsedTime % _workRateInterval;
            }

            _state._workMeter += Time.deltaTime * _workRate * _state._workMultiplier;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void StartWorking()
    {
        StartCoroutine("Work");
    }

    public void StopWorking()
    {
        StopCoroutine("Work");
    }
}
