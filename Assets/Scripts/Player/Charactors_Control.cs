using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Charactors_Control : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject bulletPosition;
	public GameObject hpGauge;
	private GameObject TimerText,ScoreText;
	[SerializeField] BulletPool bulletPool;
	public int hp = 3;
	public int score = 0;
	private float time = 0.0f,interval = 0.0f;
	public static int score_sum = 0;
	public static float time_fin = 0.0f;
	AudioSource aud;
	public AudioClip damageSE;
	
	void Start()
	{
		this.aud = GetComponent<AudioSource>();
		this.TimerText = GameObject.Find("Time");
		this.ScoreText = GameObject.Find("Score");
	}
    void Update()
    {
		Control();
		this.interval += Time.deltaTime;
		Shot();
		this.time += Time.deltaTime;
		this.TimerText.GetComponent<Text>().text = "時間:" + this.time.ToString("F1") + "秒";
		this.ScoreText.GetComponent<Text>().text = "得点:" + this.score.ToString() + "点";
		if(hp==0)
		{
			score_sum = score;
			time_fin = time;
		}
	}

	//移動処理
	private void Control()
	{
		if (Input.GetKey (KeyCode.D))
		{// 右方向の移動入力
			Vector2 pos = transform.position;
			if(pos.x < -4.00)
			{
				pos.x += 0.05f;
				transform.position = pos;
			}
		}
		else if (Input.GetKey (KeyCode.A))
		{// 左方向の移動入力
			Vector2 pos = transform.position;
			if(pos.x > -8.00)
			{
				pos.x -= 0.05f;
				transform.position = pos;
			}
		}
		else if (Input.GetKey (KeyCode.W))
		{// 上方向の移動入力
			Vector2 pos = transform.position;
			if(pos.y < 4.00)
			{
				pos.y += 0.05f;
				transform.position = pos;
			}
		}
		else if (Input.GetKey (KeyCode.S))
		{// 下方向の移動入力
			Vector2 pos = transform.position;
			if(pos.y > -4.00)
			{
				pos.y -= 0.05f;
				transform.position = pos;
			}
		}	
	}

	//弾の撃ち出し処理
	private void Shot()
	{
		if(this.interval>=0.2f)
		{
			if(Input.GetMouseButtonDown(0))
        	{
        	    bulletPool.Fire(transform.position);
				this.interval = 0.0f;
        	}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Bullet")
		{
			this.aud.PlayOneShot(this.damageSE);
		}
	}
}