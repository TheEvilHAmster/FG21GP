using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private AnimationCurve _distribution;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private bool stopSpawning = false;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnRate;
    
    
    [SerializeField] private new Camera camera;




    // Spawns inside the camera view
    void SpawnEnemy()
    {
        
        float spawnY = Random.Range
            (camera.ScreenToWorldPoint(new Vector2(0, 0)).y, camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (camera.ScreenToWorldPoint(new Vector2(0, 0)).x, camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
     
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        
        Instantiate(enemy[(int)_distribution.Evaluate(Random.value)], spawnPosition, transform.rotation);
        if (!stopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    //Spawns outside the camera view
    void SpawnOutsideCameraView()
    {
        
        
        float RandomXvalue()
        {
            return Random.Range
                (camera.ScreenToWorldPoint(new Vector2(0, 0)).x-10, camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x+10);
        }
        
        float RandomYvalue()
        {
            return Random.Range
                (camera.ScreenToWorldPoint(new Vector2(0, 0)).y-10, camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y+10);
        }


        float spawnY = RandomYvalue();
        float spawnX = RandomXvalue();

        beforeScheck:;
        if (spawnX <= camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x && spawnX >= camera.ScreenToWorldPoint(new Vector2(0, 0)).x && spawnY <= camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y && spawnY >= camera.ScreenToWorldPoint(new Vector2(0, 0)).y)
        {
            spawnY = RandomYvalue();
            spawnX = RandomXvalue();
            goto beforeScheck;
        }
        
        
        
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        
        // random enemy based on Distribution
       // Instantiate(enemy[(int)_distribution.Evaluate(Random.value)], spawnPosition, transform.rotation);
        
       //random based on my own funk 40% 0, 20% 1, 20% 2, 10% 3
        Instantiate(enemy[RandomChanseOutOfthings()], spawnPosition, transform.rotation);
        
        if (!stopSpawning)
        {
            CancelInvoke("SpawnOutsideCameraView");
        }
    }

    private void FixedUpdate()
    {
        InvokeRepeating("SpawnOutsideCameraView", spawnTime, spawnRate);
    }

    private void Awake()
    {
        camera = Camera.main;
        SpawnOutsideCameraView();
    }

    int RandomChanseOutOfthings()
    {
        int randomnum = Random.Range(0, 100);
        int num = 0;

        if (randomnum < 40 )
        {
            num = 0;
        }
        else if (randomnum < 75)
        {
            num = 1;
        }
        else if (randomnum < 95)
        {
            num = 2;
        }
        else if (randomnum < 100)
        {
            num = 3;
        }
        
        return num;
    }
}
