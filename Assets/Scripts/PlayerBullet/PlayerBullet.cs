using UnityEngine;

/// <summary>
/// �÷��̾� �Ѿ��� ��ü���� �κ��� ����� ��ũ��Ʈ.
/// </summary>
public class PlayerBullet : MonoBehaviour
{
    /// <summary>
    /// �Ѿ��� ������
    /// </summary>
    [SerializeField]
    private float bulletDamage;

    /// <summary>
    /// �ܺ� Ŭ���������� �� �� �ְ� �б� ���� ������Ʈ�� �����Ѵ�.
    /// </summary>
    public float BulletDamage => bulletDamage;
}
