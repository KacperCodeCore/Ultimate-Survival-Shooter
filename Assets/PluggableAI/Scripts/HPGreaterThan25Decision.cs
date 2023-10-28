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
        if (controller.tankHealth != null)
        {
            return controller.tankHealth.GetCurrentHealth() > controller.tankHealth.m_StartingHealth * 0.25f;
        }

        return false;
    }
}