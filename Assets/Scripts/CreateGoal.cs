using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGoal : MonoBehaviour
{
    private Goals _goal;
    private int _randomGoal;
    private Score _score;

    public photonScore _photonscore;
    // Start is called before the first frame update
    void Start()
    {
        _photonscore = GameObject.FindObjectOfType<photonScore>();
        _score = GameObject.FindObjectOfType<Score>();
        Create();
    }
    public void OnGoal()
    {
        //_photonscore.AddScore();
        _goal.isGoal = false;
        _score.AddScore();
        Create();
    }
    private void Create()
    {
        var goals = GameObject.FindObjectsOfType<Goals>();
        var goalCount = goals.Length;
        _randomGoal = Random.Range(0, goalCount);
        _goal = goals[_randomGoal];
        _goal.isGoal = true;
        Debug.Log("Random Goal: " + _goal.name);
        Debug.Log("Goals: " + goalCount);
    }
}
