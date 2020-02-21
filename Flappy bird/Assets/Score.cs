﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text text, hight;
    //順位ごとにランキングを保存する配列
    public static int[] ranks;
    //ランキングTextを表示する配列
    public Text[] texts;
    private static bool resetfrag = true;
    //現在のスコア
    public int score;
    //ハイスコアを保存するint型
    public static int save,save1,save2, savehight;
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
        if (sceneChange.scene == Scene.GamePlay)
        {
            save = 0;
        }
        //ゲームが始まってから1度だけランキングを初期生成する処理
        if (resetfrag)
        {
            for (int i = 0; i < 11; i++)
            {
                ranks = new int[11];
                ranks[i] = 0;
            }
            resetfrag = false;
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
            //ランキング外（11位）にスコアを常に代入する処理
            ranks[10] = score;
        }
        else
        {
            //ランキングがきちんと機能するようにソートする処理
            bool isEnd = false;
            int finAdjust = 1; // 最終添え字の調整値
            while (!isEnd)
            {
                bool loopSwap = false;
                for (int i = 0; i < ranks.Length - finAdjust; i++)
                {
                    //もし一つ下の順位よりスコアが低かったら入れ替える処理
                    if (ranks[i] < ranks[i + 1])
                    {
                        save1 = ranks[i];
                        save2 = ranks[i + 1];
                        ranks[i] = save2;
                        ranks[i + 1] = save1;
                        loopSwap = true;
                    }

                }
                if (!loopSwap) // Swapが一度も実行されなかった場合はソート終了
                {
                    isEnd = true;
                }
                finAdjust++;
            }
            //ランキング内のスコアを表記する処理
            for (int i=1;i<11;i++)
            {
                texts[i-1].text = i+"位"+ranks[i-1];
            }
            //スコア表記する処理
            text.text = "Score" + save;
            //ハイスコアを表記する処理
            hight.text = "HightScore" + savehight;
        }

    }
}
