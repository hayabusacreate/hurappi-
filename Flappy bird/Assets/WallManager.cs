using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    //Wallオブジェクト
    public GameObject wall;
    //壁が生成される間隔 
    public float sporntime;
    //高さ
    private float y;
    //時間
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //スポーン時間以上になったらWallを生成する処理
        if(time>sporntime)
        {
            y = Random.Range(-500, 500);
            time = 0;
            Instantiate(wall, new Vector3(10, y/100, 0), Quaternion.identity);
        }
    }
}
