using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem goal;
    [Range(0, 5)] [SerializeField] float movetime;
    void Start()
    {
        pathfinder enemyway = FindObjectOfType<pathfinder>();
        var path = enemyway.getpath();
        StartCoroutine(enemymovement(path));
    }
   IEnumerator enemymovement( List<Waypoint> pathway)
    {
        foreach (Waypoint way in pathway)
        {
            transform.position = way.transform.position;
            yield return new WaitForSeconds(movetime);
        }
        explode();
    }

    private void explode()
    {
        var vfx = Instantiate(goal, transform.position, Quaternion.identity);
        vfx.transform.position = new Vector3(60, 15, 30);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
