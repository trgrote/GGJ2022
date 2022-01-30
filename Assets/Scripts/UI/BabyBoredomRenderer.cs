using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyBoredomRenderer : MonoBehaviour
{
  [SerializeField] BabyState _state; 
  [SerializeField] Text _text;
  void Start()
  {
    _text = GetComponent<Text>();
  }

  void Update()
  {
    _text.text = $"Boredom = {_state._boredom}";
  }
}
