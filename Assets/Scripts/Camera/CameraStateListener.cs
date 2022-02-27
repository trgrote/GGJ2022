using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateListener : MonoBehaviour
{
    [SerializeField] GameState _state;

    void OnEnabled()
    {
        _state.OnStateChanged += OnStateChanged;
    }

    void OnDisabled()
    {
        _state.OnStateChanged -= OnStateChanged;
    }

    void OnStateChanged(eGameState newState)
    {
        // TODO Add state transition trigger calls
    }
}
