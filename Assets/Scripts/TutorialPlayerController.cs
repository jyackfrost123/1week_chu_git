using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerController : MonoBehaviour
{
   //speedを制御する
    [SerializeField] private float speed = 1;
    //[SerializeField] GameObject fire;
    //[SerializeField] GameObject canvas;
    [SerializeField] private FixedJoystick m_VariableJoystick;
    Rigidbody rb;

    [SerializeField] GameObject pad;
    parametorController para;
    bool isSmapho = false;
    
    

    void Start(){
        //同一のGameObjectが持つRigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

        if(GameObject.Find("NCMBSettings") != null){
            m_VariableJoystick = pad.GetComponent<FixedJoystick>();
            para = GameObject.Find("NCMBSettings").GetComponent<parametorController>();
            isSmapho = para.IsSmapho; 
        }

        if(isSmapho == true){
            pad.SetActive(true);
        }else{
            pad.SetActive(false);
        }
        

    }

    void FixedUpdate()
    {
        float x = 0.0f;
        float z = 0.0f;

        //入力をxとzに代入
        //x = Input.GetAxis("Horizontal");
        // if(m_VariableJoystick != null) 
        //z = Input.GetAxis("Vertical");
        if(isSmapho == true){
            x = m_VariableJoystick.Horizontal;
            z = m_VariableJoystick.Vertical;
        }else{
            //入力をxとzに代入
             x = Input.GetAxis("Horizontal");
            // if(m_VariableJoystick != null) 
            z = Input.GetAxis("Vertical");
             // if(m_VariableJoystick != null) z = m_VariableJoystick.Vertical;
        }

        //rigidbodyのx軸(横)とz軸(奥)に力を加える、x,zにspeedを掛ける
        rb.AddForce(x * speed, 0, z * speed);

        //MouseMove();
    }
}
