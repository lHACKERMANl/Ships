using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShip : MonoBehaviour
{
    [SerializeField] public float life;
    [SerializeField] public float damage;
    [SerializeField] public  SpriteRenderer curSprite;
    [SerializeField] public GameObject hitEffect;
    [SerializeField] public Sprite newShip, okShip, shitShip;

    public  abstract void OnCollisionEnter2D(Collision2D other);

}
