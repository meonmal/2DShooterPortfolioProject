using UnityEngine;

/// <summary>
/// 플레이어의 컨트롤을 담당하는 스크립트.
/// 이동, 공격등을 여기에서 처리한다.
/// </summary>
public class PlayerControll : MonoBehaviour
{
    /// <summary>
    /// 플레이어의 이동속도
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 플레이어 총알 프리팹
    /// </summary>
    [SerializeField]
    private GameObject bulletPrefab;

    /// <summary>
    /// 총알 소환 위치
    /// </summary>
    [SerializeField]
    private Transform spawnPosition;

    /// <summary>
    /// 발사 쿨타임
    /// </summary>
    [SerializeField]
    private float coolTime;

    /// <summary>
    /// 플레이어의 리지드바디2D
    /// </summary>
    private Rigidbody2D rigid;

    /// <summary>
    /// 이 또한 쿨타임
    /// </summary>
    private float nextTime;

    private void Awake()
    {
        // 리지드바디2D 가져오기
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 총알을 발사하는 함수를 FixedUpdate에 넣으면
        // 오히려 느리게 발사된다.
        Shoot();
    }

    /// <summary>
    /// 균일하게 움직이게 만들기 위해 그냥 Update가 아닌 FixedUpdate를 이용해 움직이게 만든다.
    /// </summary>
    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// 플레이어의 이동을 담당하는 스크립트
    /// </summary>
    private void Movement()
    {
        // 수평과 수직의 입력값을 구한다.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 위에서 구한 값들을 정규화하여 지역변수 pos에 넣어주고
        Vector2 pos = new Vector2(horizontal, vertical).normalized;
        // Rigidbody2D를 이용해 moveSpeed만큼의 속도로 움직이게 한다.
        rigid.linearVelocity = pos * moveSpeed;

        // Vector3타입의 지역변수를 선언후
        Vector3 position = transform.position;
        // Mathf.Clamp를 이용해 최소 최대 이동 범위를 지정한다.
        position.x = Mathf.Clamp(position.x, -9f, 9f);
        position.y = Mathf.Clamp(position.y, -5f, 5f);
        transform.position = position;
    }

    /// <summary>
    /// 플레이어가 총알을 발사하게 만드는 함수
    /// </summary>
    private void Shoot()
    {
        // 쿨타임이 지나지 않았으면 함수를 실행하지 않는다.
        if(Time.time < nextTime)
        {
            return;
        }

        // z와 마우스 왼쪽 버튼을 누르고 있으면 실행
        if(Input.GetKey(KeyCode.Z) || Input.GetMouseButton(0))
        {
            PlayerState playerState = GetComponent<PlayerState>();
            // 총알 소환(총알 프리팹을 소환 위치에, 회전 없이 소환한다.)
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition.position, Quaternion.identity);
            bullet.GetComponent<PlayerBullet>().SetDamage(playerState.Damage);

            // 다음 발사시간 갱신
            nextTime = Time.time + coolTime;
        }
    }
}
