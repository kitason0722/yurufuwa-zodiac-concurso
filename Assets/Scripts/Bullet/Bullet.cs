using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletspeed = 10;
    private Charactors_Control charactorsControl;
    BulletPool bulletPool;
    
    void Start()
    {
        gameObject.SetActive(false);
        bulletPool = transform.parent.GetComponent<BulletPool>();
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            charactorsControl = player.GetComponent<Charactors_Control>();
        }
    }
    void Update()
    {
        Move();
        Delete();
    }

    private void Move() 
    {
        transform.position += new Vector3(bulletspeed, 0, 0) * Time.deltaTime;
    }

    //画面外に出たら消す
    private void Delete() 
    {
        if (this.transform.position.x > 9)
        {
            bulletPool.Collect(this);
        }
    }

    public void ShowInStage(Vector3 _pos)
    {
        //追記　positionを渡された座標に設定
        transform.position = _pos;
    }

    //bulletがPlayer以外にぶつかったら消滅
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletPool.Collect(this);
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.CompareTag("Enemy"))
        {
            bulletPool.Collect(this);
            if(charactorsControl!=null)
            {
                charactorsControl.score += 100;
            }
            Destroy(collision.gameObject);
        }
    }
}
