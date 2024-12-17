using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edit_TimeScore : MonoBehaviour
{
    GameObject timeText,scoreText;
    void Start()
    {
        timeText = GameObject.Find("Time");
        scoreText = GameObject.Find("Score");

        timeText.GetComponent<Text>().text = "生き残った時間: " + Charactors_Control.time_fin.ToString("F1") + "秒";
        scoreText.GetComponent<Text>().text = "獲得得点: " + Charactors_Control.score_sum.ToString() + "点";
    }
}
