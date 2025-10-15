using UnityEngine;

public class EmotionalAIController : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 3f;
    public int pushCount = 0;
    public float calmDownTime = 5f;

    private float calmTimer;

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Calm down timer resets when player is near
        if (distance < chaseDistance)
        {
            calmTimer = 0f;
        }
        else
        {
            calmTimer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pushCount++;
        }
    }

    public bool IsAnnoyed() => pushCount >= 3 && pushCount < 6;
    public bool IsMad() => pushCount >= 6;
    public bool IsHappy(float distance)
    {
        // Returns true if player is far away and calm time has passed
        return distance > chaseDistance && calmTimer > calmDownTime;
    }
}
