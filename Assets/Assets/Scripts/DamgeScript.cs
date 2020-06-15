using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeScript : AbstractShip
{
    public override void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            life -= 50;
        }
    }

    void Update()
    {
        if(life == 150){
            curSprite.sprite = newShip;
        }
        if(life <= 100){
            curSprite.sprite = okShip;
        }
        if(life <= 50){
            curSprite.sprite = shitShip;
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