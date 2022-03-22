using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIButtonController : MonoBehaviour
{
     void Start()
    {
        var image = GetComponent<Image>();
        image.DOFade(1.0f, 1.5f);
    }

    void ShowWindow()
    {
        transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }
}
