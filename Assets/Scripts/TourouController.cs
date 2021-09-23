using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourouController : MonoBehaviour
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

    /*void MouseMove() {
        // 画面の大きさ
        float w = Screen.width;
        float h = Screen.height;
        float mForceX = 1.0f;
        float mForceZ = 30.0f;
        
        // マウスの座標
        Vector3 mp = Input.mousePosition;
        mp.z = 70f;
        Vector3 wp = Camera.main.ScreenToWorldPoint(mp);

        // 操作値
       // float x = mp.x * 2f / w - 1f;                       // -1 ~ 1
        float x = (wp.x - transform.position.x) / 12.5f;  
        float z = (wp.z - transform.position.z) / 7.5f;  
        //debugText.AddDebugMessage("w:" + w.ToString() + ", h:" + h.ToString() + ", x:" + x.ToString() + ", y:" + z.ToString());

        Vector3 move = new Vector3(mForceX * x, 0, 0);
        // 上下方向への動き
        if (Input.GetMouseButton(0)) {
            if ((z < 0 && transform.position.z > -10f) || (z > 0 && transform.position.z < 30f)) {                
            //if ((z < 0 && transform.position.z > f) || (z > 0 && transform.position.z < -30f)) { 
                move += new Vector3(0, 0, mForceZ * z);
            }      
        }
        Vector3 velo = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(move - velo, ForceMode.VelocityChange);
    }*/

    
}
