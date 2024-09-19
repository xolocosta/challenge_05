using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private const float speed = 0.5f;

    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;



    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed);
    }
}
