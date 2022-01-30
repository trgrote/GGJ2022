using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysRotateTowardsCamera : MonoBehaviour
{
    private Transform _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(_camera);
    }
}
