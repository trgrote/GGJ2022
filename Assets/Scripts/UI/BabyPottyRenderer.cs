using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyPottyRenderer : MonoBehaviour
{
  [SerializeField] BabyState _state;
  [SerializeField] Text _text;
  void Start()
  {
    _text = GetComponent<Text>();
  }

  void Update()
  {
    _text.text = "Potty = " + _state._potty.ToString("0.00");
  }
}
