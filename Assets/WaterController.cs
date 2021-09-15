using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterController : MonoBehaviour
{
    public GameObject sea;
    Rigidbody rb;

    [SerializeField]
    private float seaForce = 1.0f;
    [SerializeField] private float top;
    [SerializeField] private float bottom;

    Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        sequence = DOTween.Sequence();
        this.transform.position = new Vector3(this.transform.position.x, top, this.transform.position.z);
        //transform.DOLocalMoveY( bottom, 1f).SetLoops(-1, LoopType.Yoyo);

        sequence.Append( transform.DOLocalMoveY( bottom+0.1f*Random.Range(0.0f, 1.0f), 5f).SetEase(Ease.Unset) )
                .Append( transform.DOLocalMoveY( top+0.1f*Random.Range(0.0f, 1.0f), 5f).SetEase(Ease.OutQuad) );
                
        sequence.SetLoops(-1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*float seaTop = sea.transform.position.y + (sea.transform.localScale.y / 2.0f);
        float cubeBottom = this.transform.position.y - (this.transform.localScale.y / 2.0f);
        
        float buoyancy =  seaTop - cubeBottom;
        buoyancy = buoyancy * this.transform.localScale.x * this.transform.localScale.z;
        Debug.Log(buoyancy);

        if(buoyancy > 0.01f){
            //rb.AddForce( new Vector3(0, -Physics.gravity.y + (seaForce*buoyancy) / 10.0f, 0) );
            rb.AddForce( new Vector3(0, (seaForce*buoyancy)*-Physics.gravity.y, 0) );
            //rb.AddForce( new Vector3(0, -Physics.gravity.y,0) );
        }else{
            //rb.AddForce( new Vector3(0, 1.0f,0) );
        }*/

        
        //transform.DOMove(new Vector3(0, bottom, 0), 5f);



    }


}
