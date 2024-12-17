using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //public GameObject EnemyPrefab;
    public GameObject[] Enemy;
    private float spawnSpeed = 2.0f;
    private float time = 0.0f;
    void Start()
    { 
        //一秒間隔で実行する
        InvokeRepeating("Spawn", 1f, spawnSpeed);
        InvokeRepeating("Spawn", 1f, spawnSpeed);
    }

    void Update()
    {
        this.time += Time.deltaTime;
        if(20.0f<time&&time<=40.0f)
        {
            spawnSpeed = 1.5f;
        }
        else if(40.0f<time&&time<=60.0f)
        {
            spawnSpeed = 1.0f;
        }
        else if(60.0f<time)
        {
            spawnSpeed = 0.7f;
        }
    }
    //Enemyを生成する。
    private void Spawn()
    {
        int num = Random.Range(0,3);
        Vector2 randomPos = new Vector2(Random.Range(5,7), Random.Range(-4, 4));
        Instantiate(Enemy[num], randomPos, transform.rotation);
    }
}
