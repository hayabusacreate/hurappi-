using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//シーンごとにスクリプトをアタッチしてすぐ設定できるようにenumを使います。
public enum Scene
{
    Title,
    GamePlay,
    Result,
}
public class SceneChange : MonoBehaviour
{
    public Scene scene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //もし設定したsceneがTitleならば
        if(scene==Scene.Title)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GamePlay");
            }
        }
        //もし設定したsceneがGamePlayならば
        if (scene == Scene.GamePlay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Result");
            }
        }
        //もし設定したsceneがResultならば
        if (scene == Scene.Result)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
