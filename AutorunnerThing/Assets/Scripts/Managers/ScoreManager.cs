using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    internal TextMeshProUGUI scoreText;

   // [SerializeField]
    //internal TextMeshPro highScoreText;

    [SerializeField]
    public static float scoreCount;

    [SerializeField]
    internal float highScoreCount;

    [SerializeField]
    internal float pointsPerSecond;

    [SerializeField]
    internal GameManager gameManager;

    void Start()
    {
        scoreCount = 0;
    }

    void Update()
    {
        if(!gameManager.isDead) scoreCount += pointsPerSecond * Time.deltaTime;

        scoreText.text = "" + Mathf.Round(scoreCount) ;
    }

    public void AddScore(float amnt) 
    {
        scoreCount += amnt;
    }


}
