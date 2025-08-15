using UnityEngine;

/// <summary>
/// �÷��̾� �Ѿ��� ��ü���� �κ��� ����� ��ũ��Ʈ.
/// </summary>
public class PlayerBullet : MonoBehaviour
{
    /// <summary>
    /// �Ѿ��� ������
    /// </summary>
    private float bulletDamage;

    /// <summary>
    /// �ܺ� Ŭ���������� �� �� �ְ� �б� ���� ������Ʈ�� �����Ѵ�.
    /// </summary>
    public float BulletDamage => bulletDamage;

    public void SetDamage(float damage)
    {
        bulletDamage = damage;
    }
}
