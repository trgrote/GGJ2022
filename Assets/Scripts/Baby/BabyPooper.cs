using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyPooper : MonoBehaviour
{
    [SerializeField] GameObject _poopPrefab;
    
    public void Poop()
    {
        Instantiate(_poopPrefab, transform.position + new Vector3(0, 2f, 0f), transform.rotation);        
    }
}
