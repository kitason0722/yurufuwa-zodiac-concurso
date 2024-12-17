using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject EnemybulletPrefab;
	public GameObject EnemybulletPosition;
    void Start()
    {
        InvokeRepeating("Shot", 1f, 1f);
    }

    //弾の撃ち出し処理
	private void Shot()
    {
         Instantiate(EnemybulletPrefab,EnemybulletPosition.transform.position, transform.rotation);
    }
}
