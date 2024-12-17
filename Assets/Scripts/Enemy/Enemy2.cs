using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private int movespeed = 8;
    public GameObject EnemybulletPrefab;
	public GameObject EnemybulletPosition;
    void Start()
    {
        //一秒間隔で実行する
        InvokeRepeating("Shot", 1f, 2f);
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        if(pos.x > 0)pos += new Vector3(-movespeed, 0, 0) * Time.deltaTime;
    }

    //弾の撃ち出し処理
	private void Shot()
    {
         Instantiate(EnemybulletPrefab, EnemybulletPosition.transform.position, transform.rotation);
    }
}
