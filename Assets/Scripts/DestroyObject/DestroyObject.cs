using UnityEngine;

/// <summary>
/// 닿은 오브젝트를 삭제시키는 스크립트
/// </summary>
public class DestroyObject : MonoBehaviour
{
    private BoxCollider2D boxcoll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 닿으면 삭제시킨다.
        Destroy(collision.gameObject);
    }
}
