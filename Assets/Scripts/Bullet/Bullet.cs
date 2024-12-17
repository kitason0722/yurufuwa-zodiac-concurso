using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletspeed = 10;
    private Charactors_Control charactorsControl;
    AudioSource aud;
    public AudioClip pointSE;
    
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            charactorsControl = player.GetComponent<Charactors_Control>();
        }
        this.aud = GetComponent<AudioSource>();
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
            Destroy(this.gameObject);
        }
    }

    //bulletがPlayer以外にぶつかったら消滅
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.CompareTag("Enemy"))
        {
            this.aud.PlayOneShot(this.pointSE);
            Destroy(this.gameObject);
            if(charactorsControl!=null)
            {
                charactorsControl.score += 100;
            }
            Destroy(collision.gameObject);
        }
    }
}
