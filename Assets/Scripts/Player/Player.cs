using UnityEngine;

/// <summary>
/// �÷��̾��� ��ü���� �κ��� ����� ��ũ��Ʈ
/// �÷��̾ �ְ� �޴� ������, �÷��̾��� ���� ���
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// �÷��̾��� ������ٵ�2D
    /// </summary>
    private Rigidbody2D rigid;

    private void Awake()
    {
        // ������ٵ�2D ��������
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ������Ʈ�� �±װ� Enemy��� ����
        if (collision.CompareTag("Enemy"))
        {
            PlayerState playerState = GetComponent<PlayerState>();
            // �÷��̾��� ü�� 1 ����
            playerState.CurrentHP--;
            // �÷��̾��� ü���� 0�� ���ų� ���϶�� ����
            if(playerState.CurrentHP <= 0)
            {
                // ���ó��
                Debug.Log("�÷��̾� ���");
            }
        }
    }
}
