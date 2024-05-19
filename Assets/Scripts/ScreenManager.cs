using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;  
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScreenManager : MonoBehaviour
{
    private Image screen;
    private void Start()
    {
        screen = GetComponent<Image>();
        screen.color = new Color(0, 0, 0, 0);
    }
    public void LoadGame(string sceneName)
    {
        screen.DOFade(1, 1).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
