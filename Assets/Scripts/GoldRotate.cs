using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class GoldRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,1f,0) * (rotationSpeed * Time.deltaTime));
    }
}
