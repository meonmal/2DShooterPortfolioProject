using UnityEngine;

/// <summary>
/// ���� ������Ʈ�� ������Ű�� ��ũ��Ʈ
/// </summary>
public class DestroyObject : MonoBehaviour
{
    private BoxCollider2D boxcoll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ ������Ų��.
        Destroy(collision.gameObject);
    }
}
