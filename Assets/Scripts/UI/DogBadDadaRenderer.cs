using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBadDadaRenderer : MonoBehaviour
{
  [SerializeField] DogState _state; 
  [SerializeField] Text _text;
  void Start()
  {
    _text = GetComponent<Text>();
  }

  void Update()
  {
    _text.text = "BadDad = " + _state._badBadMeter.ToString("0.00");
  }
}
