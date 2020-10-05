using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireballController : MonoBehaviour
{
    public Text scoreDisplay;
    public Text highscoreDisplay;
    public Text gameover;
    [SerializeField] GameObject fireball;
    public bool spawned;
    public int score;
    public int test;
    [SerializeField] GameObject player;
    [SerializeField] GameObject top;
    [SerializeField] GameObject bot;
    [SerializeField] GameObject back;
    [SerializeField] GameObject floor;
    System.Random random;
    public AudioSource firesounds;

    // Start is called before the first frame update
    void Start()
    {
        firesounds = GetComponent<AudioSource>();
        random = new System.Random();
        score = 0;
        spawned = false;
        highscoreDisplay.text = "HighScore: " + PlayerPrefs.GetInt("highscore").ToString();
        gameover.text = "";
        
        GameObject.FindGameObjectWithTag("Music").GetComponent<Musical>().StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            test = random.Next(0, 2);
            if (test==0)
            {
                fireball.GetComponent<Fireball>().reset(new Vector3(top.transform.position.x, top.transform.position.y, -9));
                firesounds.Play();
                spawned = true;
            }
            else
            {
                fireball.GetComponent<Fireball>().reset(new Vector3(bot.transform.position.x, bot.transform.position.y, -9));
                firesounds.Play();
                spawned = true;
            }
        }
    }
    public void isDestroyed()
    {
        spawned = false;
        score += 100;
        SetScoreDisplay();
    }
    public void gameOver() 
    {
        PlayerPrefs.SetInt("score", score);   
        if (PlayerPrefs.GetInt("highscore") < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            
            highscoreDisplay.text = "HighScore: " + PlayerPrefs.GetInt("highscore").ToString();
        }
        PlayerPrefs.Save();
        player.GetComponent<PlayerController>().death();
        back.GetComponent<BackgroundScroll>().stopScroll();
        floor.GetComponent<BackgroundScroll>().stopScroll();
        gameover.text = "Game Over";
        Invoke("End", 1);
    }
    public float getSpeed()
    {
        if(score < 1000)
        {
            return 10;
        }
        else
        {
            return (score * 0.001f)+10f;
        }
        
    }
    void SetScoreDisplay()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }
    void End()
    {
        SceneManager.LoadScene("End");
    }
}
