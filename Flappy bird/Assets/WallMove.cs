using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    //迫ってくる速度
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //左に常に進む処理
        transform.position += new Vector3(-speed/10, 0, 0);
    }
    //画面外に出たら消す処理
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
