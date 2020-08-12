using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour
{
    
    [SerializeField] Waypoint startpoint, endpoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue=new Queue<Waypoint>();
    [SerializeField] bool isrunning = true;
    Waypoint searchcenter;
    public List<Waypoint> path = new List<Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left
    };
    
    public List<Waypoint> getpath()
    {
        if (path.Count == 0)
        {
            calculatepath();
        }
        return path;
    }

    private void calculatepath()
    {
        loadblocks();
        //colorstartend();
        breadthfirstsearch();
        createpath();
    }

    private  void createpath()
    {
        setpath(endpoint);
        Waypoint previous = endpoint.exploredfrom;
        while (previous != startpoint)
        {
            setpath(previous);
            previous = previous.exploredfrom;
        }
        setpath(startpoint);
        path.Reverse();
    }

    private void setpath(Waypoint points)          //to set path for enemy and block the player from placing tower on its way
    {
        path.Add(points);
        points.istowerplaceable = false;
    }

    private void breadthfirstsearch()
    {
        queue.Enqueue(startpoint);
        while(queue.Count>0 && isrunning)
        {
            searchcenter = queue.Dequeue();
            searchcenter.isexplored = true;
            endfound();
            exploreneighbours();
        }
    }

    private  void endfound()
    {
         if (endpoint == searchcenter)
        {
            isrunning = false;
        }
    }

    private void exploreneighbours()
    {
        if(!isrunning)
        {
            return;
        }
        foreach(Vector2Int dir in directions)
        {
            Vector2Int nearby= searchcenter.getgridpos() + dir;
            if(grid.ContainsKey(nearby))
            {
                neighbour(nearby);
            }
        }
    }

    private void neighbour(Vector2Int nearby)
    {
        Waypoint neighbours = grid[nearby];
        if(neighbours.isexplored || queue.Contains(neighbours))
        {
            //
        }
        else
        {
            queue.Enqueue(neighbours);
            neighbours.exploredfrom = searchcenter;
        } 
    }

    //private void colorstartend()
   // {
    //    startpoint.settopcolor(Color.green);
    //    endpoint.settopcolor(Color.red);
    //}

    private void loadblocks()
    {
        var waypath = FindObjectsOfType<Waypoint>();
        foreach(Waypoint way in waypath)
        {
            var gridpos = way.getgridpos();
            if (grid.ContainsKey(gridpos))
            {
                Debug.LogWarning("overlapping"+way);
            }
            else
            {
                grid.Add(gridpos, way);
            }
        }
    }
}
