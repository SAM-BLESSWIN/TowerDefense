using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerfactory : MonoBehaviour
{
    [SerializeField] tower towerprefab;
    [SerializeField] int towerlimit = 5;
    Queue<tower> towerqueue = new Queue<tower>();
    [SerializeField] Transform towerparent;
    public void addtower(Waypoint location)
    {
        int towercount = towerqueue.Count;
        if(towercount<towerlimit)
        {
            towerinstantiate(location);
        }
        else
        {
            maxtower(location);
        }
    }
    private void towerinstantiate(Waypoint location)
    {
        var newtower=Instantiate(towerprefab, location.transform.position, Quaternion.identity);
        newtower.transform.parent = towerparent;

        newtower.basewaypoint = location;
        location.istowerplaceable = false;

        towerqueue.Enqueue(newtower);
    }
    private  void maxtower(Waypoint newlocation)
    {
        var oldtower=towerqueue.Dequeue();
        
        oldtower.basewaypoint.istowerplaceable = true;
        newlocation.istowerplaceable = false;

        oldtower.transform.position = newlocation.transform.position;
        oldtower.basewaypoint = newlocation;

        towerqueue.Enqueue(oldtower);
    }
}
