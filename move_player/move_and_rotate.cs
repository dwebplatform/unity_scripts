using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSattilight : MonoBehaviour
{
    Rigidbody _playerBody;
    private float horizontalOffset => Input.GetAxis("Horizontal");
    private float verticalOffset => Input.GetAxis("Vertical");
    private Vector3 _dir;
    private float _movementSpeed = 40f;
    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody>();
    }
    private Vector3 getOffset()
    {
        _dir = new Vector3(horizontalOffset, 0, verticalOffset).normalized;
        Vector3 offset = _dir * _movementSpeed * Time.deltaTime;
        return offset;
    }
    private Quaternion getRotationTo(Vector3 vectorToRotate)
    {
        Quaternion rotateFrom = transform.rotation;
        Quaternion rotateTo = Quaternion.LookRotation(vectorToRotate);
        return Quaternion.RotateTowards(rotateFrom, rotateTo, 360*Time.fixedDeltaTime);
    }
    void Update()
    {
        Vector3 offset = getOffset();
        if (offset != Vector3.zero)
        {
            _playerBody.MovePosition(transform.position + offset);
            _playerBody.MoveRotation(getRotationTo(offset));
        }

    }
}
