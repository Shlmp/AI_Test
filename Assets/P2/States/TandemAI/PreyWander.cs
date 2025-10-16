using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PreyWander", menuName = "FSM/States/Tandem_AI/Prey/WanderAI")]
public class PreyWander : State
{
    public float moveSpeed = 2f;
    public float pointThreshold = 0.5f;
    private Vector3 targetPoint;
    private Color wanderColor = Color.cyan;
    private NavMeshAgent agent;

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai != null)
        {
            SetColor(ai, wanderColor);
            targetPoint = ai.GetRandomWanderPoint();
            Debug.Log("AI is wandering around.");
            ai.TryGetComponent(out agent);
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai == null) return;

        if (Vector3.Distance(ai.transform.position, targetPoint) < pointThreshold)
        {
            targetPoint = ai.GetRandomWanderPoint();
        }

        agent.SetDestination(targetPoint);
    }

    private void SetColor(CuriousAIController ai, Color color)
    {
        var renderer = ai.GetComponent<Renderer>();
        if (renderer) renderer.material.color = color;
    }
}
