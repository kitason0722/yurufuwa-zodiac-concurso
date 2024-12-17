using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Bullet_e3 : MonoBehaviour
{
    private GameObject player;
    public Vector2 bulletspeed = new Vector2(0.03f,0.03f);
    private float rad;
    private Vector2 Position;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rad = Mathf.Atan2(
            player.transform.position.y-transform.position.y,
            player.transform.position.x-transform.position.x);
    }
    void Update()
    {
        Move();
        Delete();
    }

    private void Move() 
    {
        Position = transform.position;
        Position.x += bulletspeed.x * Mathf.Cos(rad);
        Position.y += bulletspeed.y * Mathf.Sin(rad);
        transform.position = Position;
    }

    private void Delete()
    {
        if (this.transform.position.x < -9)
        {
            Destroy(this.gameObject);
        }
    }

    //bulletがEnemy以外にぶつかったら消滅
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Charactors_Control charactorsControl = collision.gameObject.GetComponent<Charactors_Control>();
            if (charactorsControl != null)
            {
                charactorsControl.hp -= 1;
                charactorsControl.hpGauge.GetComponent<Image>().fillAmount -= 0.33f;

                if (charactorsControl.hp <= 0)
                {
                    SceneManager.LoadScene("ResultScene");
                }
            }
        }
    }
}
