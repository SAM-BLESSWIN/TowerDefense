using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour
{
    public bool isexplored = false;
    public Waypoint exploredfrom;
    const int gridsize = 10;
    public bool istowerplaceable = true;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
    public int getgridsize()
    {
        return gridsize;
    }

    public Vector2Int getgridpos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridsize),
            Mathf.RoundToInt(transform.position.z / gridsize)
            );
    }
    
   // public void settopcolor(Color color)
    //{
   //     MeshRenderer top = transform.Find("top").GetComponent<MeshRenderer>();
   //     top.material.color = color;
   // }

    void OnMouseOver()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            if (istowerplaceable)
            {
                FindObjectOfType<towerfactory>().addtower(this);
            }
            else
            {
                print("blocked");
            }
        }*/
        if(Input.touchCount>0)
        {
            if (istowerplaceable)
            {
                FindObjectOfType<towerfactory>().addtower(this);
            }
            else
            {
                print("blocked");
            }
        }
    }


}
