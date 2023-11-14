using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HPGreaterThan25")]
public class HPGreaterThan25Decision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool hpGreaterThan25 = CheckHP(controller);
        return hpGreaterThan25;
    }

    private bool CheckHP(StateController controller)
    {
        if (controller.iTankHealth != null)
        {
            return controller.iTankHealth.CurrentHealth > controller.iTankHealth.MaxHealth * 0.45f;
        }

        return false;
    }
}