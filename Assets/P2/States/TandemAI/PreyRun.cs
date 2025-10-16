using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PreyRun", menuName = "FSM/States/Tandem_AI/Prey/RunAI")]
public class PreyRun : State
{
    public float fleeSpeed = 5f;
    private Color scaredColor = Color.red;
    private NavMeshAgent agent;

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai != null)
        {
            ai.SetScaredTimer();
            SetColor(ai, scaredColor);
            Debug.Log("AI is scared and running away!");
            ai.TryGetComponent(out agent);
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai == null || ai.player == null) return;

        Vector3 dir = (ai.transform.position - ai.player.position).normalized;
        agent.SetDestination(dir * fleeSpeed);
    }

    private void SetColor(CuriousAIController ai, Color color)
    {
        var renderer = ai.GetComponent<Renderer>();
        if (renderer) renderer.material.color = color;
    }
}
