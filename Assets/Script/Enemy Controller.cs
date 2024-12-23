using UnityEngine;

public class EnemyControlleR : MonoBehaviour
{
    // ��������� ������ �� ����� Pos � Pos1 � ���������� Unity
    public Transform pos;
    public Transform pos1;

    // �������� ��� �����
    public Animator animator;

    private void Update()
    {
        // ���������, �������� �� ���� Pos ��� Pos1
        if (IsTouchingPositions())
        {
            animator.SetTrigger("idle"); // ������ �������� "Idle"
        }
        else
        {
            animator.SetTrigger("run"); // ������ �������� "Run"
        }
    }

    private bool IsTouchingPositions()
    {
        // ��������� ���������� ����� ������ � Pos, � ����� ����� ������ � Pos1
        float distanceToPos = Vector3.Distance(transform.position, pos.position);
        float distanceToPos1 = Vector3.Distance(transform.position, pos1.position);

        // ���� ���������� ������ ������������ ������, ���������, ��� ���� �������� �����
        float detectionRadius = 0.3f; // ��������� ������ �� �������������
        return distanceToPos <= detectionRadius || distanceToPos1 <= detectionRadius;
    }
}
