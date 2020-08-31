using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    
    Text _text;
    public Text currentScore;
    public Text highScore;
    
    
    void Awake()
    {
        _text = GetComponent<Text>();
        Score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = " "+ Score;
        currentScore.text = _text.text;
        if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            highScore.text = Score.ToString();
        }
    }
}
