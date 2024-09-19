using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;
    void Start()
    {
        System.Random r = new System.Random();
        for (int i=0; i<1000; i++){
            if (i%5==0){
                for (int obj=0; obj<=asteroids.Length-1; obj++){
                    Instantiate(asteroids[obj].gameObject, new Vector2(r.Next(-100,100), r.Next(-100,100)), Quaternion.identity);
                }   
            }
            
        }
          
    }

}
