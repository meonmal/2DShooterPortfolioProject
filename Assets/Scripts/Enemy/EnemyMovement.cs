using UnityEngine;

/// <summary>
/// ���� �̵���Ű�� ��ũ��Ʈ
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// �̵��ӵ�
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        Movement();
    }

    /// <summary>
    /// ���� �̵��ϰ� ����� �Լ�
    /// </summary>
    private void Movement()
    {
        // �������� pos�� ������ ��, �� ������ �������� �̵��ϴ� Vector3���� �־��ش�.
        Vector3 pos = new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        // ���� ��ġ���� pos�� ����ŭ �����̰� ������ش�.
        transform.position += pos;
    }
}
