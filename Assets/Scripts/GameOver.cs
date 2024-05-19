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
    public ScreenManager ScreenManager;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void GameFinish()
    {
        Text tmpro = GetComponent<Text>();
        DOVirtual.DelayedCall(0, () => {
            var text = "GameOver";
            tmpro.DOText(text, 1f).OnComplete(() => {
                DOVirtual.DelayedCall(delayTime, () =>
                {
                    ScreenManager.LoadGame("Title");
                });
            });
        });
    } 
}
