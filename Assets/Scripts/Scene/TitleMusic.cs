using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMusic : MonoBehaviour
{
    static public TitleMusic instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public AudioSource TitleBGM,GameBGM;
    private string beforeScene;
    void Start()
    {
        beforeScene = "TitleScene";
        TitleBGM.Play();
        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    void OnActiveSceneChanged(Scene prevScene,Scene nextScene)
    {
        if(beforeScene == "TitleScene" && nextScene.name == "GameScene")
        {
            TitleBGM.Stop();
            GameBGM.Play();
        }

        if(beforeScene == "GameScene" && nextScene.name == "ResultScene")
        {
            GameBGM.Stop();
        }

        if(beforeScene == "ResultScene" && nextScene.name == "TitleScene")
        {
            TitleBGM.Play();
        }
        beforeScene = nextScene.name;
    }
}
