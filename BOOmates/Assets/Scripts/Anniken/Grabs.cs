using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabs : Chores
{
    [SerializeField]
    protected GameObject targetPosition;
    
    void Start()
    {
        targetPosition.SetActive(false);
    }

    public override void placed()
    {
        Vector2 item = new Vector2(transform.position.x, transform.position.z);
        Vector2 target = new Vector2(targetPosition.transform.position.x, targetPosition.transform.position.z);
        if(checkItemInPos(target, item, 1)){
            transform.position = new Vector3(target.x, transform.position.y, target.y);
            targetPosition.gameObject.SetActive(false);
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
            this.tag = "PositionedItem";
            _complete = true;
        }
    }
    

    bool checkItemInPos(Vector2 target, Vector2 item, float radius)
    {
        return Vector2.Distance(target, item) < radius;
    }

    public override void finishClean()
    {
        Debug.LogError("Object type is not Clean");
        return;
    }

    public override void activeChore(int ghostid)
    {
        base.activeChore(ghostid);
        _active = true;
    }

    public override void deactiveChore(int ghostid)
    {
        base.deactiveChore(ghostid);
        targetPosition.SetActive(false);
        _active = false;
    }

    public override GameObject getTargetPosition()
    {
        return targetPosition;
    }
}
