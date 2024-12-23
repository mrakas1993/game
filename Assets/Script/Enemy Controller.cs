using UnityEngine;

public class EnemyControlleR : MonoBehaviour
{
    // Размещаем ссылки на точки Pos и Pos1 в инспекторе Unity
    public Transform pos;
    public Transform pos1;

    // Аниматор для врага
    public Animator animator;

    private void Update()
    {
        // Проверяем, касается ли враг Pos или Pos1
        if (IsTouchingPositions())
        {
            animator.SetTrigger("idle"); // Играть анимацию "Idle"
        }
        else
        {
            animator.SetTrigger("run"); // Играть анимацию "Run"
        }
    }

    private bool IsTouchingPositions()
    {
        // Проверяем расстояние между врагом и Pos, а также между врагом и Pos1
        float distanceToPos = Vector3.Distance(transform.position, pos.position);
        float distanceToPos1 = Vector3.Distance(transform.position, pos1.position);

        // Если расстояние меньше определённого порога, считается, что враг касается точки
        float detectionRadius = 0.3f; // Настройте радиус по необходимости
        return distanceToPos <= detectionRadius || distanceToPos1 <= detectionRadius;
    }
}
