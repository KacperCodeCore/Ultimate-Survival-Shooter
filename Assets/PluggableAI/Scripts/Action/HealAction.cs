using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Heal")]
public class HealAction : Action
{
    public override void Act(StateController controller)
    {
        Heal(controller);
    }

    private void Heal(StateController controller)
    {
        controller.iTankHealth.HealAmount(5 * Time.deltaTime);
    }
}
