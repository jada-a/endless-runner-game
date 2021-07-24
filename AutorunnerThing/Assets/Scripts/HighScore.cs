using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    private static readonly string HighScorePref = "HighScorePref";
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = Mathf.Round(PlayerPrefs.GetFloat(HighScorePref, 0)).ToString();
    }

}
