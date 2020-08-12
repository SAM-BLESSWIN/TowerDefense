using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int hits=10;
    [SerializeField] Text healthtext;
    [SerializeField] AudioClip playersfx;
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        healthtext.text = health.ToString();
    }
    public void OnTriggerEnter(Collider other)
    {
        damage();
        destroyed();
    }
    
    private void damage()
    {
        GetComponent<AudioSource>().PlayOneShot(playersfx);
        health = health - hits;
        healthtext.text = health.ToString();
    }
    private void destroyed()
    {
        if(health<=0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
