using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public Button button;

    public int level;

    private void Start()
    {
        button.onClick.AddListener(() => LoadNextLevel(level));
        transition.SetTrigger("End");
    }
    void Update()
    {
         
    }

    public void LoadNextLevel(int index) 
    {
        StartCoroutine(LoadLevel(index));
         
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        Debug.Log("StartingAnimation");

        yield return new WaitForSecondsRealtime(transitionTime);
        Debug.Log(levelIndex);

        SceneManager.LoadScene(levelIndex);
        transition.ResetTrigger("Start");


    }
}
