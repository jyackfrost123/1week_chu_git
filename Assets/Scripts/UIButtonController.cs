using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIButtonController : MonoBehaviour
{
     void Start()
    {
        //transform.localScale = Vector3.zero;
        //ShowWindow();
        //this.GetComponent<Image>().color.DOFade(endValue: 256f, duration: 1.5f);
        var image = GetComponent<Image>();
        //image.color.a = 0.0f;
        //image.color = new color();
        image.DOFade(1.0f, 1.5f);
    }

    void ShowWindow()
    {
        transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }
}
