using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float pointsPerSecond;

    public Text score;
    public Text hiScoreText;
    public float Score;
    private float hiScore;

    public bool isScoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        isScoreIncreasing = true;
        if (PlayerPrefs.HasKey("HiScoreText"))
            hiScore = PlayerPrefs.GetFloat("HiScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoreIncreasing)
            Score += pointsPerSecond * Time.deltaTime;

        if(Score > hiScore)
        {
            hiScore = Score;
            PlayerPrefs.SetFloat("HiScoreText", hiScore);
        }

        score.text = Mathf.Round(Score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();
    }
}
