using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float forceY;
    [SerializeField] private float rotatespeed = 100f;

    private Vector2 vector;
    private float speedX, speedY;
    private bool forward, backward;
    
    
    void Update()
    {
        Inputs();
        Move();
        Rotate();
        Force();
    }


    private void Inputs()
    {
        forward = Input.GetKey(KeyCode.W);
        backward = Input.GetKey(KeyCode.S);
    }
    private void Move()
    {
        if (forward && !backward)
            speedY += forceY * Time.deltaTime;
        else if (!forward && backward)
            speedY -= forceY * Time.deltaTime;
    }
    private void Rotate()
    {
        double dx = Input.mousePosition.x - Screen.width / 2.0;
        double dy = Input.mousePosition.y - Screen.height / 2.0;
        float sdx = (float)dx;
        float sdy = (float)dy;


        float sR = -Mathf.Atan2(sdx, sdy);
        float sD = 360 * sR / (2 * Mathf.PI); // radians to degrees

        Quaternion target = Quaternion.Euler(0.0f, 0f, sD);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * rotatespeed);
    }
    private void Force()
    {
        transform.position += new Vector3(speedX, 0f);
        transform.position += transform.up * speedY;
    }
}
