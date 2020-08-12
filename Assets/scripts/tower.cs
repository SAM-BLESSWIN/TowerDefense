using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    [SerializeField] Transform gun;
    Transform target;
    [SerializeField] float firingrange = 10f;
    [SerializeField] ParticleSystem bullets;
    public Waypoint basewaypoint;

    void Update()
    {
        settarget();
        if(target)
        {
            gun.LookAt(target);
            fireatenemy();
        }
       else
        {
            shoot(false);
        }
    }
    private void settarget()
    {
        var spawnenemy =  FindObjectsOfType<enemyhit>();
        if(spawnenemy.Length==0)
        {
            return;
        }
        Transform closestenemy = spawnenemy[0].transform;
        foreach (enemyhit testenemy in spawnenemy)
        {
            closestenemy = getclosestenemy(closestenemy, testenemy.transform);
        }
        target = closestenemy;
    }
     private Transform getclosestenemy(Transform enemy1,Transform enemy2)
    {
        float enemy1dis=Vector3.Distance(enemy1.position, gameObject.transform.position);
        float enemy2dis=Vector3.Distance(enemy2.position, gameObject.transform.position);
        if(enemy1dis<enemy2dis)
        {
            return enemy1;
        }
         else
         {
            return enemy2;
         }
    }
    private void fireatenemy()
    {
        float dis = Vector3.Distance(target.transform.position, gameObject.transform.position);
        if(dis<=firingrange)
        {
            shoot(true);
        }
        else
        {
            shoot(false);
        }
    }

    private  void shoot(bool isactive)
    {
        var firing = bullets.emission;
        firing.enabled = isactive;
    }
}
