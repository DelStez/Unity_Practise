using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationAxes
{
    MouseXY = 0,
    MouseX = 1,
    MouseY =2
}
public class MouseLook : MonoBehaviour
{
    public RotationAxes axes = RotationAxes.MouseXY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;

    public float minVer = -45.0f;
    public float maxVer = 45.0f;

    private float _rotationX = 0;
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") *sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVer, maxVer);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVer, maxVer);
            float delta = Input.GetAxis("Mouse X") *sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
