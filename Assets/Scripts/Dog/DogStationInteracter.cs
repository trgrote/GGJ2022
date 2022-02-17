using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DogStationInteracter : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _stations;
    [SerializeField] rho.RuntimeGameObjectSet _pickups;
    List<GameObject> _usableStations = new List<GameObject>();

    [SerializeField] GameObject _interactText;
    [SerializeField] DogState _state;

    [SerializeField] Transform _holdPosition;
    [SerializeField] Transform _dropPosition;
    Transform _heldObject;

    void Start()
    {
        _interactText.SetActive(false);
        _state._mode = DogStateMode.WALKING;
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

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        switch (_state._mode)
        {
            case DogStateMode.WALKING:
            {
                if (_usableStations.Count() > 0)
                {
                    var mostRecentAddition = _usableStations.Last();

                    if (mostRecentAddition != null)
                    {
                        if (_pickups.Contains(mostRecentAddition))
                        {
                            _heldObject = mostRecentAddition.transform.parent;
                            _heldObject.SendMessage("Pickup");

                            _heldObject.parent = _holdPosition;
                            _heldObject.localRotation = Quaternion.identity;
                            _heldObject.localPosition = Vector3.zero;
                            // Pickup object
                            _state._mode = DogStateMode.HOLDING;
                        }
                        else if (_stations.Contains(mostRecentAddition))
                        {
                            // TODO Start Operating on Station
                            _state._mode = DogStateMode.WORKING;
                            SendMessage("StartWorking");
                        }
                    }
                }
                break;
            }
            case DogStateMode.HOLDING:
            {
                // Drop Object
                _heldObject.parent = null;
                _heldObject.position = _dropPosition.position;
                _heldObject.SendMessage("Drop");
                _state._mode = DogStateMode.WALKING;
                break;
            }
            case DogStateMode.WORKING:
            {
                _state._mode = DogStateMode.WALKING;
                SendMessage("StopWorking");
                break;
            }
        }
    }
}
