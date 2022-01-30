using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogWorkRenderer : MonoBehaviour
{
  [SerializeField] DogState _state;
  [SerializeField] Text _text;
  void Start()
  {
    _text = GetComponent<Text>();
  }

  void Update()
  {
    _text.text = $"Work = {_state._workMeter}";
  }
}
