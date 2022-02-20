using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDadListener : MonoBehaviour
{
    [SerializeField] DogState _dogState;
    [SerializeField] BabyState _babyState;
    [SerializeField] float _poopInsideValue = 0.1f;
    [SerializeField] float _badDadInsideRate = 0.01f;

    void OnEnable()
    {
        _dogState.OnIsInsideChanged += OnInsideStateChanged;
        _babyState.OnIsInsideChanged += OnInsideStateChanged;
    }

    void OnDisable()
    {
        _dogState.OnIsInsideChanged -= OnInsideStateChanged;
        _babyState.OnIsInsideChanged -= OnInsideStateChanged;
    }

    // Update is called once per frame
    public void OnPoop()
    {
        if (_babyState.isInside)
            _dogState._badBadMeter += _poopInsideValue;
    }

    public void OnInsideStateChanged()
    {
        if (!_babyState.isInside && _dogState.isInside && _babyState._mode == BabyStateMode.ON_GROUND)
        {
            StartCoroutine("IncrementBadDad");
        }
        else
        {
            StopCoroutine("IncrementBadDad");
        }
    }

    IEnumerator IncrementBadDad()
    {
        while (true)
        {
            yield return null;
            _dogState._badBadMeter += _badDadInsideRate * Time.deltaTime;
        }
    }
}
