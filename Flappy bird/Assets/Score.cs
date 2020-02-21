using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text text,hight;
    //現在のスコア
    public int score;
    //ハイスコアを保存するint型
    public static int save,savehight;
    private SceneChange sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GameObject.Find("SceneChange").GetComponent<SceneChange>();
        text = GetComponent<Text>();
        //ヒエラルキービューからHightScoreというものを探して代入する処理。
        hight = GameObject.Find("HightScore").GetComponent<Text>();
        hight.text = "HightScore" + save;
        //現在のシーンを調べてGamePlayならsaveを初期化する。
        if(sceneChange.scene==Scene.GamePlay)
        {
            save = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneChange.scene == Scene.GamePlay)
        {
            text.text = "Score" + score;
            save = score;
            //セーブされている数値が現在のscoreを超えたらテキストに反映する処理
            if (savehight <= score)
            {
                //ハイスコアの更新
                savehight = score;
                hight.text = "HightScore" + savehight;
            }
        }else
        {
            text.text = "Score" + save;
            hight.text = "HightScore" + savehight;
        }

    }
}
