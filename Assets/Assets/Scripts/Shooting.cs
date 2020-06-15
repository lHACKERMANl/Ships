using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float ballForce = 4.6f;
    [SerializeField] private int maxAmmo = 1;
    [SerializeField] private int curAmmo = -1;
    [SerializeField] private float relodeTime = 0.8f;
    [SerializeField] private bool isReloding = false;
    // Start is called before the first frame update
    void Start()
    {
        if(curAmmo == -1)
        {
            curAmmo = maxAmmo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isReloding)
            return;
        
        if(curAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButton("Fire1"))
        {
            curAmmo--;
            GameObject ball = Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloding = true;
        yield return new WaitForSeconds(relodeTime);
        curAmmo = maxAmmo;
        isReloding = false;
    }

    GameObject Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * ballForce, ForceMode2D.Impulse);
        return ball;
    }
}
