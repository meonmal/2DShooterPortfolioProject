using UnityEngine;

/// <summary>
/// 플레이어 총알의 전체적인 부분을 담당할 스크립트.
/// </summary>
public class PlayerBullet : MonoBehaviour
{
    /// <summary>
    /// 총알의 데미지
    /// </summary>
    private float bulletDamage;

    /// <summary>
    /// 외부 클래스에서도 쓸 수 있게 읽기 전용 컴포넌트로 생성한다.
    /// </summary>
    public float BulletDamage => bulletDamage;

    public void SetDamage(float damage)
    {
        bulletDamage = damage;
    }
}
