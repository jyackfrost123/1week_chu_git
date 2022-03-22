using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialTourouController : MonoBehaviour
{
    
    [SerializeField]private GameObject fire;

    [SerializeField]private GameObject player;
    [SerializeField]private bool isFire = false;

    [SerializeField] private GameObject fireSE;
    [SerializeField] private GameObject nextTourou;

    private TutorialitemController itemCon;

    // Start is called before the first frame update
    void Start(){
        fire.SetActive(false);
        player = GameObject.Find("Player");
        this.transform.DOLocalMoveY(player.transform.position.y, 2.0f);
        itemCon = GameObject.Find("ItemGenerator").GetComponent<TutorialitemController>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(player.transform.position.z > this.transform.position.z + 10.0f){
            if(itemCon.TourouNum > 0) itemCon.TourouNum--;
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player" && isFire == false){
            fire.SetActive(true);
            //灯篭の消失演出を入れる
            StartCoroutine("Fade");
            isFire = true;
        }
    }

    IEnumerator Fade()  {
        Instantiate(fireSE, this.transform.position , Quaternion.identity);
        yield return new WaitForSeconds (2.0f);

        if(itemCon.TourouNum > 0)itemCon.TourouNum--;
        DOTweenSequence();
        //yield return null;  
    }

    void DOTweenSequence(){
        //Sequenceのインスタンスを作成
        var sequence = DOTween.Sequence();

        //Appendで動作を追加していく
        sequence.Append(this.transform.DOLocalMoveY(3.0f, 5.0f));
        sequence.Join(fire.transform.DOLocalMoveY(16.0f, 5.0f));

        //Playで実行
        sequence.Play().OnComplete(() =>{
            Instantiate(nextTourou, new Vector3(9.5f * Random.Range(-1.0f, 1.0f), -2.0f, 7.5f * Random.Range(-1.0f, 1.0f)), Quaternion.identity);
            Destroy(this.gameObject);
        });
    }



}
