using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveText : MonoBehaviour
{
    [SerializeField] DogState _state;
    TextMesh _text;

    void Start()
    {
        _text = GetComponent<TextMesh>();
    }

    void Update()
    {
        switch (_state._mode)
        {
            case DogStateMode.WALKING:
                _text.text = "Press E";
                break;
            case DogStateMode.WORKING:
                _text.text = "Working...";
                break;
            case DogStateMode.HOLDING:
                _text.text = "Press E to Drop";
                break;
        }
    }
}
