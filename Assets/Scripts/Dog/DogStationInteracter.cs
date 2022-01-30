using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DogStationInteracter : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _stations;
    List<GameObject> _usableStations = new List<GameObject>();

    [SerializeField] GameObject _interactText;

    void Start()
    {
        _interactText.SetActive(false); 
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (_stations.Contains(collider.gameObject))
        {
            _usableStations.Add(collider.gameObject);
            _interactText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (_stations.Contains(collider.gameObject))
        {
            _usableStations.Remove(collider.gameObject);
            if (_usableStations.Count() == 0)
            {
                _interactText.SetActive(false);                
            }
        }        
    }
}
