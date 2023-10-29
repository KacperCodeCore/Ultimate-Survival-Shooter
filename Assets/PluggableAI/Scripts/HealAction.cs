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
        float health = controller.tankHealth.GetCurrentHealth() + 5 * Time.deltaTime;
        controller.tankHealth.SetCurrentHealth(health);
        controller.tankHealth.SetHealthUI();
    }
}
