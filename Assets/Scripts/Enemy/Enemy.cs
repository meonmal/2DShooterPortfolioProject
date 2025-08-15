using UnityEngine;

/// <summary>
/// ���� ��ü���� �κ��� ����ϴ� ��ũ��Ʈ
/// �������� �ְ� �ޱ�, ���� ���� ���
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// ���� �ִ� ü��
    /// </summary>
    [SerializeField]
    private float maxHP;
    /// <summary>
    /// ���� ���� ü��
    /// </summary>
    [SerializeField]
    private float currentHP;

    /// <summary>
    /// ���� ������ٵ�2D
    /// </summary>
    private Rigidbody2D rigid;

    private void Awake()
    {
        // ���� ü�� �ʱ�ȭ
        currentHP = maxHP;
        // ������ٵ�2D ��������
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ���� ������Ʈ�� �±װ� PlayerBullet�̸� ����
        if (collision.CompareTag("PlayerBullet"))
        {
            // �ڱ�� ���� ������Ʈ���Լ� PlayerBullet ������Ʈ�� ã�ƿ´�.
            PlayerBullet bullet = collision.GetComponent<PlayerBullet>();
            // ����ü�¿��� BulletDamage��ŭ ���ҽ�Ų��.
            currentHP -= bullet.BulletDamage;
            // ���� ���� ü���� 0�� ���ų� ���϶�� ����
            if(currentHP <= 0)
            {
                // �� ���� ������Ʈ ����
                Destroy(gameObject);
            }

            // ���� ������Ʈ�� ������Ų��.
            Destroy(collision.gameObject);
        }
    }
}
