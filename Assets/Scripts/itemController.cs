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
    private itemGenerateController gen;

    // Start is called before the first frame update
    void Start(){
        fire.SetActive(false);
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        player = GameObject.Find("Player");
        this.transform.DOLocalMoveY(player.transform.position.y, 2.0f);
        gen = GameObject.Find("ItemGenerator").GetComponent<itemGenerateController>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(this.transform.position.z > player.transform.position.z + 30.0f || this.transform.position.z < player.transform.position.z - 20.0f 
            || this.transform.position.x > player.transform.position.x + 22.0f || this.transform.position.x < player.transform.position.x - 22.0f ){
                if(gen.ItemNum > 0) gen.ItemNum--;
                Destroy(this.gameObject);
            
        }
    }


    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player" && isFire == false){
            fire.SetActive(true);
            ui.AddScore(point);
            if(gen.ItemNum > 0) gen.ItemNum--;
            //灯篭の消失演出を入れる
            StartCoroutine("Fade");
            isFire = true;
        }
    }

    IEnumerator Fade()  {
        Instantiate(fireSE, this.transform.position , Quaternion.identity);
        yield return new WaitForSeconds (2.0f);  

        DOTweenSequence();
        yield return null;  
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
}
