using UnityEngine;

[CreateAssetMenu(fileName = "InvestigationComplete", menuName = "FSM/Conditions/AI_V2/Curious/InvestigationComplete")]
public class InvestigationComplete : Condition
{
    public float investigationTime = 5f; // how long before returning to wandering

    public override bool Check(StateMachine stateMachine)
    {
        if (stateMachine == null) return false;

        // Use the shared timer in FSMContext
        stateMachine.context.investigationTimer += Time.deltaTime;

        if (stateMachine.context.investigationTimer >= investigationTime)
        {
            // reset timer for next time
            stateMachine.context.investigationTimer = 0f;
            return true;
        }

        return false;
    }
}
