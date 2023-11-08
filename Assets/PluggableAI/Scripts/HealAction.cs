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
        float health = controller.iTankHealth.CurrentHealth + 5 * Time.deltaTime;
        controller.iTankHealth.HealAmount = health;
        controller.tankHealth.SetHealthUI();
    }
}
