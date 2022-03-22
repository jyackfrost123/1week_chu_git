using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace jyackfrostNamespace{

    public class WaterController : MonoBehaviour{
        public GameObject sea;
        Rigidbody rb;

        //[SerializeField] private float seaForce = 1.0f;
        //[SerializeField] private float top;
        //[SerializeField] private float bottom;

        Sequence sequence;

        // Start is called before the first frame update
        void Start(){
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate(){

            float seaTop = sea.transform.position.y + (sea.transform.localScale.y / 2.0f);
            float cubeBottom = this.transform.position.y - (this.transform.localScale.y / 2.0f);
        
            float buoyancy =  seaTop - cubeBottom;
            buoyancy = buoyancy * this.transform.localScale.x * this.transform.localScale.z;
            Debug.Log(buoyancy);

            if(buoyancy > 0.01f){
                rb.AddForce( new Vector3(0, -Physics.gravity.y/40.0f, 0) );
            }



        }
    }
    
}
