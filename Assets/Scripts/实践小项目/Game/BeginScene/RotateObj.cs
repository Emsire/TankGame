using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float rotateRange = 360f;
    private float rotateTotal = 0f;
    void Update()
    {
        rotateTotal += rotateSpeed * Time.deltaTime;
        if (rotateTotal >= rotateRange || rotateTotal <= -rotateRange)
        {
            rotateSpeed = -rotateSpeed;
            rotateTotal = 0f;
        }
        this.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
