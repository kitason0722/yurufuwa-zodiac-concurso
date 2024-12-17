using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet_e2 : MonoBehaviour
{
    private int bulletspeed = 7;
    
    void Update()
    {
        Move();
        Rotation();
        Delete();
    }

    private void Move() 
    {
        transform.position += new Vector3(-bulletspeed, 0, 0) * Time.deltaTime;
    }

    //画面外に出たら消す
    private void Delete() 
    {
        if (this.transform.position.x < -9)
        {
            Destroy(this.gameObject);
        }
    }

    private void Rotation()
    {
        transform.Rotate(new Vector3(0,0,5));
    }

    //bulletがEnemy以外にぶつかったら消滅
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
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
