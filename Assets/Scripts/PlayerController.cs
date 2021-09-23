using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //speedを制御する
    [SerializeField] private float speed = 1;
    [SerializeField] public GameObject gamePad;
    [SerializeField] FixedJoystick m_VariableJoystick;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject canvas;
    UIController ui;//for Start
    Rigidbody rb;
    

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
                    // if(m_VariableJoystick != null) 
                    z = Input.GetAxis("Vertical");
                    // if(m_VariableJoystick != null) z = m_VariableJoystick.Vertical;
                }

            }
        }




        //rigidbodyのx軸(横)とz軸(奥)に力を加える、x,zにspeedを掛ける
        rb.AddForce(x * speed, 0, z * speed);


        //MouseMove();
    }
}
