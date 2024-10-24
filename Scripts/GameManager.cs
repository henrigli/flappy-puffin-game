using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject restartButton;
    public GameObject gameOver;
    private int score;
    public GameObject eatParticle;
    public Parallax parallaxGround;
    public Parallax parallaxBackground;
    public Spawner speed;
    public Spawner delay;
    private int newGame = 0;

    [SerializeField] TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;

    private void Awake(){
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        highScoreText.enabled = false;
        newHighScoreText.enabled = false;
        restartButton.SetActive(false);
        UpdateHighScoreText();
        Pause();

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && newGame == 0){
            Play();
            newGame = 1;
        }
    }

    public void Play(){
        playButton.SetActive(false);
        restartButton.SetActive(false);
        gameOver.SetActive(false);
        highScoreText.enabled = false;
        newHighScoreText.enabled = false;
        score=0;
        scoreText.text = "0";

        Time.timeScale = 1f;
        player.enabled = true;

        Fishes[] fishes = FindObjectsOfType<Fishes>();
        for (int i = 0; i<fishes.Length;i++) {
            Destroy(fishes[i].gameObject);
        }

        Seagulls[] seagulls = FindObjectsOfType<Seagulls>();
        for (int i = 0; i<seagulls.Length;i++) {
            Destroy(seagulls[i].gameObject);
        }

        Clouds[] clouds = FindObjectsOfType<Clouds>();
        for (int i = 0; i<clouds.Length;i++) {
            Destroy(clouds[i].gameObject);
        }

        Eagles[] eagles = FindObjectsOfType<Eagles>();
        for (int i = 0; i<eagles.Length;i++) {
            Destroy(eagles[i].gameObject);
        }


    }

    public void Pause(){
        Time.timeScale = 0f;
        player.enabled = false;

    }

    public void GameOver() {
        gameOver.SetActive(true);
        restartButton.SetActive(true);
        CheckHighScore();
        UpdateHighScoreText();
        highScoreText.enabled = true;
        Pause();
    }

    public void RestartGame() {
            newGame=0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
         }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
        Instantiate (eatParticle, player.transform.position, player.transform.rotation);
        
    }

    public void CheckHighScore() {
        if(score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
            newHighScoreText.enabled = true;

        }
    }

    public void UpdateHighScoreText() {
        highScoreText.text = $"HI-SCORE:{PlayerPrefs.GetInt("HighScore", 0)}";
    }
    
    
}
