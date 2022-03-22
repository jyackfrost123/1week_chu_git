using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parametorController : MonoBehaviour
{
    [SerializeField] private int hiscore = 0;
    public int HiScore{
        set{this.hiscore = value;}
        get{ return this.hiscore;}
    }

    [SerializeField] private int oldScore = 0;
    public int OldScore{
        set{this.oldScore = value;
            if(oldScore >= hiscore) hiscore = oldScore;
        }
        get{ return this.oldScore;
        }
    }

    [SerializeField] private bool isFirst = false;
    public bool IsFirst{
        set{this.isFirst = value;}
        get{ return this.isFirst;}
    }

    [SerializeField] private bool isSmapho = false;
    public bool IsSmapho{
        set{this.isSmapho = value;}
        get{ return this.isSmapho;}
    }

    //ResultControllerを要確認
    public string HyokaMessage(){
        string s = "";

        if(oldScore < 60){
            s = "山火事";
            return s;
        }else if(oldScore < 120){
            s = "1/5文字";
            return s;
        }else if(oldScore < 180){
            s = "2/5文字";
            return s;
        }else if(oldScore < 240){
            s = "小文字";
            return s;
        }else if(oldScore < 300){
            s = "中文字";
            return s;
        }

        s = "大文字";
        return s;
    }

    

}
