using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class DogInputHandler : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField] float _speed = 1f;
    [SerializeField] DogState _state;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _state._currentMovement = Vector3.zero;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_state._mode == DogStateMode.WORKING) return;
        
        var direction = context.ReadValue<Vector2>();
        if (direction.sqrMagnitude > 0)
        {
            _state._currentMovement = new Vector3(direction.x, 0, direction.y) * _speed;
        }
        else
        {
            _state._currentMovement = Vector3.zero;
        }
    }

    void Update()
    {
        _controller.SimpleMove(_state._currentMovement);
    }
}
