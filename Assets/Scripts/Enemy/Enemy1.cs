using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour
{
    public GameObject target,scoreText;
    private int movespeed = 10;

    void Start()
    {
        scoreText = GameObject.Find("Score");
    }
    void Update()
    {
        Move();
        Delete();
    }

    private void Move()
    {
        transform.position += new Vector3(-movespeed, 0, 0) * Time.deltaTime;
    }

    private void Delete()
    {
        if (this.transform.position.x < -9) Destroy(this.gameObject);
    }

      //EnemyがPlayerにぶつかったら消滅
      //EnemyがPlayer_Bulletにぶつかったら得点を更新
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

                if (charactorsControl.hp == 0)
                {
                    SceneManager.LoadScene("ResultScene");
                }
            }
        }
    }
}
