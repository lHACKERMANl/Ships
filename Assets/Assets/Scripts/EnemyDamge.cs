using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class EnemyDamge : AbstractShip
{

    public override void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "EnemyEz")
        {
            life -= 50;
        }
        if(other.gameObject.tag == "EnemyMid")
        {
            life -= 100;
        }
        if(other.gameObject.tag == "EnemyHard")
        {
            life -= 150;
        }
        if(other.gameObject.tag == "Enemy")
        {
            life -= damage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        life = 150f;
        damage = 50f;
        gameObject.tag = "Player";
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
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.34f);
            Destroy(gameObject);
        }
    }
}
