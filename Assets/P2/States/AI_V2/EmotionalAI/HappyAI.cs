using UnityEngine;

[CreateAssetMenu(fileName = "HappyAI", menuName = "FSM/States/AI_V2/HappyAI")]
public class HappyAI : State
{
    public float moveSpeed = 2f;
    public float greetingDistance = 2f;

    private Color happyColor = Color.green;

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        if (ai != null)
        {
            ai.pushCount = 0;
            SetColor(ai, happyColor);
            Debug.Log("AI is Happy!");
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        if (ai == null || ai.player == null) return;

        float distance = Vector3.Distance(ai.transform.position, ai.player.position);

        // Move closer and "greet" if near
        if (distance > greetingDistance)
        {
            Vector3 dir = (ai.player.position - ai.transform.position).normalized;
            ai.transform.position += dir * moveSpeed * Time.deltaTime;
        }
        else
        {
            // simple rotation to face player
            ai.transform.LookAt(ai.player);
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
