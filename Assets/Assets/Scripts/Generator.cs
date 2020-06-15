﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject enemyEz, enemyMid, enemyHard;
    [SerializeField] private float rand1, rand2, rangeX, rangeY;
    [SerializeField] private Vector2 spawnPoint;
    [SerializeField] private float spawnRate = 6f;
    [SerializeField] private float nextSpawn = 0.0f;
    [SerializeField] private Camera cam;
    public GameObject[] enemys;

    public static int scorVal = 0;
    Text score;


    void Start()
    {
        enemys = new GameObject[] {enemyEz, enemyMid, enemyHard};
        score = GetComponent<Text>();
    }

    void Update()
    {
        spawnLvl();
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time +spawnRate;
            rangeX = RandomZone(-5f,-4f,4f,5f);
            rangeY = RandomZone(-3,2,2,3);
            spawnPoint = new Vector2 (rangeX, rangeY);
            Instantiate(enemys[Random.Range(0,3)], spawnPoint, Quaternion.identity);
        }

        score.text = " Score: " + scorVal;
    }

    float RandomZone(float n1, float n2, float m1, float m2)
    {
        rand1 = Random.Range(n1, n2); rand2 = Random.Range(m1,m2);
        float[] range = new float[] {rand1, rand2};
        return range[Random.Range(0,2)];
    }

    void spawnLvl()
    {
        if(scorVal >= 100){spawnRate = 5f;}
        if(scorVal >= 500){spawnRate = 4f;}
        if(scorVal >= 800){spawnRate = 3f;}
        if(scorVal >= 1000){spawnRate = 2f;}
        if(scorVal >= 2000){spawnRate = 1f;}
    }
}
