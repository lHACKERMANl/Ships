using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamge : DamgeScript
{
    public int hpCount;

    public Image[] hearts;
    public Image gameOver;
    public Button restart;
    public Sprite fullHearts;
    public Sprite empthuHearts;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "EnemyEz")
        {
            life -= 50;
            hpCount--;
        }
        if(other.gameObject.tag == "EnemyMid")
        {
            life -= 100;
            hpCount = hpCount - 2;
        }
        if(other.gameObject.tag == "EnemyHard")
        {
            life -= 150;
            hpCount = hpCount - 3;
        }
        if(other.gameObject.tag == "Enemy")
        {
            life -= damage;
        }
        if(life <= 0)
        {
            gameOver.enabled = true;
            Cursor.visible = true; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        gameObject.tag = "Player";
    }

    void FixedUpdate()
    {
        for(int i=0;i<hearts.Length;i++)
        {

            if(i<hpCount)
            {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
