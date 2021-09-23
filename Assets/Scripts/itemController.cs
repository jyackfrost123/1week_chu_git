using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class itemController : MonoBehaviour{
    
    [SerializeField]private GameObject fire;

    [SerializeField]private UIController ui;
    [SerializeField]private int point = 10;
    
    [SerializeField]private GameObject player;
    [SerializeField]private bool isFire = false;

    [SerializeField] private GameObject fireSE;

    // Start is called before the first frame update
    void Start(){
        fire.SetActive(false);
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        player = GameObject.Find("Player");
        this.transform.DOLocalMoveY(player.transform.position.y, 2.0f);
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(player.transform.position.z > this.transform.position.z + 10.0f){
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player" && isFire == false){
            fire.SetActive(true);
            ui.AddScore(point);
            //灯篭の消失演出を入れる
            StartCoroutine("Fade");
            isFire = true;
        }
    }

    void DOTweenSequence(){
        //Sequenceのインスタンスを作成
        var sequence = DOTween.Sequence();

        //Appendで動作を追加していく
        //sequence.Append(this.transform.DOMoveX(5f, 2f));
        sequence.Append(this.transform.DOLocalMoveY(3.0f, 5.0f));
        sequence.Join(fire.transform.DOLocalMoveY(16.0f, 5.0f));

        //Playで実行
        sequence.Play().OnComplete(() =>{
            Destroy(this.gameObject);
        });
    }

    IEnumerator Fade()  {
        Instantiate(fireSE, this.transform.position , Quaternion.identity);
        yield return new WaitForSeconds (2.0f);  
        DOTweenSequence();
        yield return null;  
    }
}
