using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletPool :MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] int max_count;
    Queue<Bullet> bulletQueue;
    Queue<Bullet_e2>bullet_e2Queue;
    Queue<Bullet_e3>bullet_e3Queue;
    Vector3 setpos = new Vector3(100,100,0);
    private void Awake()
    {
        bulletQueue = new Queue<Bullet>();

        for(int i = 0;i < max_count;i++)
        {
            Bullet tmpbullet = Instantiate(bullet,setpos,Quaternion.identity,transform);
            bulletQueue.Enqueue(tmpbullet);
        }
    }

    public Bullet Fire(Vector3 _pos)
    {
        if (bulletQueue.Count <= 0) return null;
        Bullet tmpBullet = bulletQueue.Dequeue();
        tmpBullet.gameObject.SetActive(true);
        tmpBullet.ShowInStage(_pos);
        return tmpBullet;
    }

    //弾の回収処理
    public void Collect(Bullet _bullet)
    {
        _bullet.gameObject.SetActive(false);
        //Queueに戻す
        bulletQueue.Enqueue(_bullet);
    }
}
