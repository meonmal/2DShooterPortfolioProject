using UnityEngine;

/// <summary>
/// �÷��̾��� ��ü���� �κ��� ����� ��ũ��Ʈ
/// �÷��̾ �ְ� �޴� ������, �÷��̾��� ���� ���
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// �÷��̾��� ü��
    /// </summary>
    [SerializeField]
    private float playerHP;

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
            // �÷��̾��� ü�� 1 ����
            playerHP--;
            // �÷��̾��� ü���� 0�� ���ų� ���϶�� ����
            if(playerHP <= 0)
            {
                // ���ó��
                Debug.Log("�÷��̾� ���");
            }
        }
    }
}
