using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Rotate360Degrees")]
public class Rotate360DegreesAction : Action
{
    public override void Act(StateController controller)
    {

        Rotate360Degrees(controller);

    }

    private void Rotate360Degrees(StateController controller)
    {

    }
}
