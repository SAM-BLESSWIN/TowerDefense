using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class boxeditor: MonoBehaviour
{
    TextMesh textmesh;
    Waypoint waypoint;
    GameObject render;

    public void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        snapgrid();
        textlabel();
    }

    private void snapgrid()
    {
        int gridsize = waypoint.getgridsize();
        transform.position = new Vector3(
            waypoint.getgridpos().x * gridsize,
            0f,
            waypoint.getgridpos().y * gridsize
            );

    }
    private void textlabel()
    {
        
        textmesh = GetComponentInChildren<TextMesh>();
        string label = waypoint.getgridpos().x + "," + waypoint.getgridpos().y;
        textmesh.text = label;
        gameObject.name = label;
    }
}
