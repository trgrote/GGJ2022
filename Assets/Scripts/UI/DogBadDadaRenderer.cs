using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBadDadaRenderer : MonoBehaviour
{
  [SerializeField] DogState _state;
  Text _text;
  void Start()
  {
    _text = GetComponent<Text>();
  }

  void Update()
  {
    _text.text = $"Potty = {_state._badBadMeter}";
  }
}
