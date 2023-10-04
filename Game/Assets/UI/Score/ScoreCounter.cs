using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TMP_Text ScoreText;
    public int currentScore = 0;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = " SCORE: " + currentScore.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentScore += v;
        ScoreText.text = " SCORE: " + currentScore.ToString();

    }

  
}
