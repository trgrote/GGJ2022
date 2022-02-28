using System.Collections;
using System.Collections.Generic;
using rho;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraStateListener : MonoBehaviour
{
    [SerializeField] GameState _state;
    Animator _anim;

    void OnEnabled()
    {
        _state.Changed += OnStateChanged;
    }

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
        switch (_state.Value)
        {
            case eGameState.TITLE:
                _anim.SetTrigger("ToTitle");
                break;
            case eGameState.GAMEMODE:
                _anim.SetTrigger("ToGamemode");
                break;
            default:
                break;
        }
    }

    void OnDisabled()
    {
        _state.Changed -= OnStateChanged;
    }

    void OnStateChanged(ExternalVariable<eGameState> sender, eGameState oldValue, eGameState newValue)
    {
        switch (newValue)
        {
            case eGameState.TITLE:
                _anim.SetTrigger("ToTitle");
                break;
            case eGameState.GAMEMODE:
                _anim.SetTrigger("ToGamemode");
                break;
            default:
                break;
        }
    }
}
