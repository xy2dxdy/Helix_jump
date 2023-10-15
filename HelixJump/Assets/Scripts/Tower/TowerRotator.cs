using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;
    private float _torque;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                _torque = touch.deltaPosition.x * _rotateSpeed * Time.deltaTime;
                _rigidbody.AddTorque(Vector3.up * -_torque);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                _rigidbody.AddTorque(Vector3.down * _torque);
            }
            
        }
    }
}
