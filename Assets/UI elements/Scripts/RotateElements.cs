using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateElements : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private bool rotateRight;
    private void Start()
    {
        rotateSpeed = rotateRight ? -rotateSpeed : rotateSpeed;
    }
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }
}
