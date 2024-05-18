using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private int _score = 0;
    private TextMeshProUGUI _scoreText;
    private void Start() 
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        ResetScore();
    }
    public void AddScore()
    {
        _score++;
        if (_scoreText != null)
        {
            _scoreText.text = _score.ToString();
        }
    }
    public void ResetScore()
    {
        _score = 0;
        if (_scoreText != null)
        {
            _scoreText.text = _score.ToString();
        }
    }
}
