using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ジャンプ力
    public float jumpPower=5;
    private Rigidbody rigidbody;
    private Vector3 JumpPos;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerのRigidbodyを代入
        rigidbody = gameObject.transform.GetComponent<Rigidbody>();
        //ジャンプ力をrigidbody.velocityに代入するためにVector3に変換
        JumpPos = new Vector3(0, jumpPower, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //スペース押したらジャンプ
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = JumpPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        score.score++;
    }
}
