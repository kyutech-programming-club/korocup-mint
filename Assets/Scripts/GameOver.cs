using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        GameFinish();
    }


    public void GameFinish()
    {
        Text tmpro = GetComponent<Text>();
        DOVirtual.DelayedCall(delayTime, () => {
            var text = "GameOver";
            tmpro.DOText(text, 1f).OnComplete(() => {
                Time.timeScale = 0.0f;
            });
        });
    } 
}
