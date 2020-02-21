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

    public virtual void activeChore()
    {
        Debug.LogError("Neither Grabs or Clean to active");
    }

    public virtual void deactiveChore()
    {
        Debug.LogError("Neither Grabs or Clean to deactive");
    }

    public virtual void finishClean()
    {
        Debug.LogError("Object type is not Clean");
    }

    public virtual void placed() {
        Debug.LogError("Object type is not Grab");
    }
}



