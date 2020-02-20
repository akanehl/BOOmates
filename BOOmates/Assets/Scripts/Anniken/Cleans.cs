using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleans : Chores
{

    public override bool complete()
    {
        return base.complete();
    }

    public override void finishClean()
    {
        _complete = true;
    }

    public override void placed() {
        base.placed();
    }
}
