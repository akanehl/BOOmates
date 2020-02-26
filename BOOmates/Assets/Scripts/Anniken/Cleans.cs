using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleans : Chores
{


    public override void finishClean()
    {
        _complete = true;
    }

    public override void placed() {
        base.placed();
    }

    public override void activeChore(int ghostid)
    {
        base.activeChore(ghostid);
        _active = true;
    }

    public override void deactiveChore(int ghostid)
    {
        base.deactiveChore(ghostid);
        _active = false;
    }

    public override GameObject getTargetPosition()
    {
        return base.getTargetPosition();
    }

}
