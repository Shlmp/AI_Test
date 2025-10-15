using UnityEngine;

[CreateAssetMenu(fileName = "MadAI", menuName = "FSM/States/AI_V2/MadAI")]
public class MadAI : State
{
    public float chaseSpeed = 4f;
    public float attackRange = 1.5f;

    private Color madColor = Color.red;

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        if (ai != null)
        {
            SetColor(ai, madColor);
            Debug.Log("AI is Angry!");
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        if (ai == null || ai.player == null) return;

        float distance = Vector3.Distance(ai.transform.position, ai.player.position);

        // Chase player aggressively
        if (distance > attackRange)
        {
            Vector3 dir = (ai.player.position - ai.transform.position).normalized;
            ai.transform.position += dir * chaseSpeed * Time.deltaTime;
        }
        else
        {
            ai.transform.LookAt(ai.player);
            // Simulate attacks
            Debug.Log("AI attacks the player!");
        }
    }

    private void SetColor(EmotionalAIController ai, Color color)
    {
        var renderer = ai.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
