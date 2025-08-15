using UnityEngine;

/// <summary>
/// 플레이어의 전체적인 부분을 담당할 스크립트
/// 플레이어가 주고 받는 데미지, 플레이어의 스탯 등등
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// 플레이어의 리지드바디2D
    /// </summary>
    private Rigidbody2D rigid;

    private void Awake()
    {
        // 리지드바디2D 가져오기
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 닿은 오브젝트의 태그가 Enemy라면 실행
        if (collision.CompareTag("Enemy"))
        {
            PlayerState playerState = GetComponent<PlayerState>();
            // 플레이어의 체력 1 감소
            playerState.CurrentHP--;
            // 플레이어의 체력이 0과 같거나 이하라면 실행
            if(playerState.CurrentHP <= 0)
            {
                // 사망처리
                Debug.Log("플레이어 사망");
            }
        }
    }
}
