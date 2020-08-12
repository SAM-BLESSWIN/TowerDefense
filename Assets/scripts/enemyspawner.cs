using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyspawner : MonoBehaviour
{
    [Range(1F,100F)] [SerializeField] float spawntime;
    [SerializeField] enemy enemyprefab;
    [SerializeField] Transform enemyparent;
    [SerializeField] Text enemy;
    [SerializeField] AudioClip enemyspawnsfx;
    int enemycount=0;

    void Start()
    {
        enemy.text = enemycount.ToString();
        StartCoroutine(enemyspawn());
    }
     IEnumerator enemyspawn()
    {
        while (true)
        {
            var villan = Instantiate(enemyprefab, transform.position, Quaternion.identity);
            villan.transform.parent = enemyparent;
            points();
            GetComponent<AudioSource>().PlayOneShot(enemyspawnsfx);
            yield return new WaitForSeconds(spawntime);
        }
    }

    private void points()
    {
        enemycount++;
        enemy.text = enemycount.ToString();
        PlayerPrefs.SetInt("score", enemycount);
    }
}
