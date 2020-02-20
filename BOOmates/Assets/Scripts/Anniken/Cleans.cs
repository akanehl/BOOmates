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

    public override void activeChore()
    {
        _active = true;
    }

    public override void deactiveChore()
    {
        _active = false;
    }
}
