using UnityEngine;

/// <summary>
/// 적의 전체적인 부분을 담당하는 스크립트
/// 데미지를 주고 받기, 적의 스탯 등등
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 적의 최대 체력
    /// </summary>
    [SerializeField]
    private float maxHP;
    /// <summary>
    /// 적의 현재 체력
    /// </summary>
    [SerializeField]
    private float currentHP;

    /// <summary>
    /// 적의 리지드바디2D
    /// </summary>
    private Rigidbody2D rigid;

    private void Awake()
    {
        // 현재 체력 초기화
        currentHP = maxHP;
        // 리지드바디2D 가져오기
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 만일 닿은 오브젝트의 태그가 PlayerBullet이면 실행
        if (collision.CompareTag("PlayerBullet"))
        {
            // 자기와 닿은 오브젝트에게서 PlayerBullet 컴포넌트를 찾아온다.
            PlayerBullet bullet = collision.GetComponent<PlayerBullet>();
            // 현재체력에서 BulletDamage만큼 감소시킨다.
            currentHP -= bullet.BulletDamage;
            // 만익 현재 체력이 0과 같거나 이하라면 실행
            if(currentHP <= 0)
            {
                // 적 게임 오브젝트 삭제
                Destroy(gameObject);
            }

            // 닿은 오브젝트를 삭제시킨다.
            Destroy(collision.gameObject);
        }
    }
}
