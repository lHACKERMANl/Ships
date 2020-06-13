using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;


    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.34f);
        Destroy(gameObject);
    }

    void Update() {
        Destroy(gameObject, 3f);
    }
}
