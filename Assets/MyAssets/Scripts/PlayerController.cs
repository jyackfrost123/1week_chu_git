using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //speedを制御する
    [SerializeField] private float speed = 1;
    [SerializeField] public GameObject gamePad;
    [SerializeField] private FixedJoystick m_VariableJoystick;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject fire2;
    [SerializeField] private GameObject ExplosionSE;
    UIController ui;//for Start
    Rigidbody rb;
    bool isExplosion = false;
    

    void Start(){
        //同一のGameObjectが持つRigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        m_VariableJoystick = gamePad.GetComponent<FixedJoystick>();

        if(canvas != null) ui = canvas.GetComponent<UIController>();

    }

    void FixedUpdate()
    {
        float x = 0.0f;
        float z = 0.0f;
        if(canvas != null){
            if(ui.isStart == true){
                if(ui.isPad == true){
                    x = m_VariableJoystick.Horizontal;
                    z = m_VariableJoystick.Vertical;
                }else{
                    //入力をxとzに代入
                    x = Input.GetAxis("Horizontal");
                    z = Input.GetAxis("Vertical");
                }

            }

            if(ui.isEnd == true & isExplosion == false){
                fire.SetActive(false);
                Instantiate(fire2, this.transform.position, Quaternion.identity);
                Instantiate(ExplosionSE, this.transform.position, Quaternion.identity);
                isExplosion = true;
            }
        }
 
        rb.AddForce(x * speed, 0, z * speed);
        
    }
}
