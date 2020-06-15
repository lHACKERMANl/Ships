using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] public int hpCount;
    public Image[] hearts;
    [SerializeField] public Image gameOver;
    [SerializeField] public Button restart;
    [SerializeField] public Sprite fullHearts;
    [SerializeField] public Sprite empthuHearts;

    public void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "EnemyEz")
        {
            hpCount--;
        }
        if(other.gameObject.tag == "EnemyMid")
        {
            hpCount = hpCount - 2;
        }
        if(other.gameObject.tag == "EnemyHard")
        {
            hpCount = hpCount - 3;
        }
        LoseHeartCheck();
        if(hpCount <= 0)
        {
            gameOver.enabled = true;
            Cursor.visible = true; 
        }
    }

        void Start()
    {
        gameOver.enabled = false;
    }

    void LoseHeartCheck()
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
