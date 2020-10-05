using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("score").ToString();
        highscore.text = "highScore: " + PlayerPrefs.GetInt("highscore").ToString();
    }
}
