using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Chores: MonoBehaviour
{
    [SerializeField]
    protected int id;
    [SerializeField]
    protected Sprite choreIcon;
    [SerializeField]
    [TextArea(3,10)]
    protected string discription;
    protected bool _complete = false;

    protected bool _active = false;
    [SerializeField]
    protected Material defalutMaterial;
    [SerializeField]
    protected Material ghost1Material;
    [SerializeField]
    protected Material ghost2Material;

    public int getID()
    {
        return id;
    }

    public Sprite getChoreIcon()
    {
        return choreIcon;
    }

    public bool complete() {
        return _complete;
    }

    public bool isActive()
    {
        return _active;
    }

    public virtual void activeChore(int ghostid)
    {
        Renderer rend = GetComponent<Renderer>();
        if(rend != null)
        {
            if(ghostid == 0)
                rend.material = ghost1Material;
            else
                rend.material = ghost2Material;
        }
    }

    public virtual void deactiveChore(int ghostid)
    {
        Renderer rend = GetComponent<Renderer>();
        if(rend != null)
            rend.material = defalutMaterial;
    }

    public virtual void finishClean()
    {
        Debug.LogError("Object type is not Clean");
    }

    public virtual void placed() {
        Debug.LogError("Object type is not Grab");
    }

    public virtual GameObject getTargetPosition()
    {
        Debug.LogError("not grabbing");
        return null;
    }
}



