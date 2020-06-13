using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeScript : MonoBehaviour
{
    public float life = 50f;
    public float damage = 50f;
    public GameObject hitEffect;
    public SpriteRenderer curSrite;
    public Sprite newShip, okShip, shitShip;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            life -= 50;
        }
    }

    void Start()
    {
        //gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 150){
            curSrite.sprite = newShip;
        }
        if(life <= 100){
            curSrite.sprite = okShip;
        }
        if(life <= 50){
            curSrite.sprite = shitShip;
        }
        if(life <= 0){
            if(this.gameObject.tag == "EnemyEz") {Generator.scorVal += 10;}
            if(this.gameObject.tag == "EnemyMid") {Generator.scorVal += 50;}
            if(this.gameObject.tag == "EnemyHard") {Generator.scorVal += 100;}
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.34f);
            Destroy(gameObject);
        }
    }
}
