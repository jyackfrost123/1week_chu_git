using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

   parametorController para;
   //public GameObject[] Omakes;
    
    
    void Start()
    {
     
     if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
     }
     
      
    }

    public void goTweet(){
       //naichilab.UnityRoomTweet.Tweet ("gameID", "このゲームは"+100+"点"+"とったテストです。", "unity1week", "testGame");
       if(para != null){
           string s = para.HyokaMessage();
           StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("【TOUROU】あなたの送り火は"+s+"級です https://unityroom.com/games/tourou_daimongi"));//画像あり
       }else{
           StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("【TOUROU】今回の送り火 https://unityroom.com/games/tourou_daimongi"));//画像あり
       }
       //StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("ツイート本文をここに書く"));//画像あり
    }

    public void go2ndTweet(){
       //naichilab.UnityRoomTweet.Tweet ("gameID", "このゲームは"+100+"点"+"とったテストです。", "unity1week", "testGame");
       if(para != null){
           string s = para.HyokaMessage();
           StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("【TOUROU】あなたの送り火は"+s+"級です(フリーモード) https://unityroom.com/games/tourou_daimongi"));//画像あり
       }else{
           StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("【TOUROU】今回の送り火(フリーモード) https://unityroom.com/games/tourou_daimongi"));//画像あり
       }
       //StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("ツイート本文をここに書く"));//画像あり
    }

    public void goRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.OldScore, 0);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
    }

    public void goResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 0);
    }
    
    
    
    public void go2ndRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.OldScore, 1);
    }

    public void go2ndResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 1);
    }
    
    

    public void ReStart(){
        //FadeManager.Instance.LoadScene ("GameMainTest", 0.5f);

        if(para != null) para.OldScore = 0;

        //FadeManager.Instance.LoadScene ("GameMainTest", 1.0f);

        
  
        if(para != null && para.IsFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial_1", 0.5f);
            para.IsFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameMainTest", 1.0f);
        }

        

        
                
    }

    public void Re2ndStart(){
        //FadeManager.Instance.LoadScene ("GameMainTest", 0.5f);

        if(para != null) para.OldScore = 0;

        FadeManager.Instance.LoadScene ("GameMain2", 1.0f);

        
  
        /*if(para != null && para.IsFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial_1", 0.5f);
            para.IsFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameMainTest", 1.0f);
        }*/

                
    }

    public void Fast2ndReStart(){
         SceneManager.LoadScene("GameMain2");
    }

    public void FastReStart(){
         SceneManager.LoadScene("GameMainTest");
    }

    public void goTutorial(){
        para.IsFirst = true;
        FadeManager.Instance.LoadScene ("Tutorial_1", 0.5f);
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene ("testScene", 0.5f);
    }

    public void TrueSmapho(){
        if(para != null){
            if(para.IsSmapho == false){
                para.IsSmapho = true;
            }else{
                para.IsSmapho = false;
            }
        }
        
    }


    //public void isSmaphoTrue


 
}
