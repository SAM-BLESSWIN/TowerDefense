using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class loadgame : MonoBehaviour
{
    [SerializeField] Text scorepoints;
    int i = 0;
    public void Start()
    {
        int points = PlayerPrefs.GetInt("score");
        scorepoints.text = points.ToString();
    }
    void Update()
    {
        foreach(var touch in Input.touches)
        {
            if (touch.tapCount == 2)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
     }
}
