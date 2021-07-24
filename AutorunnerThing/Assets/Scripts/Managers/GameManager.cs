using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    public GameObject gameOverCanvas;
    public CameraController cameraController;
    public AudioSource audioSource;

    private static readonly string HighScorePref = "HighScorePref";

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;

        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        if (PlayerPrefs.GetFloat(HighScorePref) < ScoreManager.scoreCount)
        {
            PlayerPrefs.SetFloat(HighScorePref, ScoreManager.scoreCount);
        }
        audioSource.Stop();
        isDead = true;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        cameraController.StopCamera();
    }

    public void Restart() 
    {
        isDead = false;
        SceneManager.LoadScene("SampleScene");
        cameraController.StartCamera();

    }
}
