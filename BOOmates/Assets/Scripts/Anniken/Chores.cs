using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Chores: MonoBehaviour
{
    [SerializeField]
    protected int id;
    [SerializeField]
    [TextArea(3,10)]
    protected string discription;
    protected bool _complete = false;

    public virtual bool complete() {
        return _complete;
    }

    public virtual void finishClean()
    {
        Debug.LogError("Object type is not Clean");
        return;
    }

    public virtual void placed() {
        Debug.LogError("Object type is not Grab");
        return;
    }
}



