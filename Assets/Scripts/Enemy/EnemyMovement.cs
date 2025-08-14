using UnityEngine;

/// <summary>
/// 적을 이동시키는 스크립트
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// 이동속도
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        Movement();
    }

    /// <summary>
    /// 적이 이동하게 만드는 함수
    /// </summary>
    private void Movement()
    {
        // 지역변수 pos를 선언한 후, 그 값으로 왼쪽으로 이동하는 Vector3값을 넣어준다.
        Vector3 pos = new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        // 현재 위치에서 pos의 값만큼 움직이게 만들어준다.
        transform.position += pos;
    }
}
