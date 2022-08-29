using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpinner : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 45, 0) * (_speed * Time.deltaTime));
    }
}
