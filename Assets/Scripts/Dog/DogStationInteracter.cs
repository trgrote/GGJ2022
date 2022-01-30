using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStationInteracter : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _stations;
    List<GameObject> _usableStations = new List<GameObject>();

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (_stations.Contains(collider.gameObject))
        {
            _usableStations.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (_stations.Contains(collider.gameObject))
        {
            _usableStations.Remove(collider.gameObject);
        }        
    }
}
