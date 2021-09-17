using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //speedを制御する
    [SerializeField]private float speed = 1;
    Rigidbody rb;
    

    void Start(){
        //同一のGameObjectが持つRigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        //入力をxとzに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");



        //rigidbodyのx軸(横)とz軸(奥)に力を加える、x,zにspeedを掛ける
        rb.AddForce(x * speed, 0, z * speed);


        //MouseMove();
    }
}
