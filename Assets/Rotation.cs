using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    private GameObject cube1, cube2;

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
