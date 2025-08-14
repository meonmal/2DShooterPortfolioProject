using UnityEngine;

/// <summary>
/// 배경의 무한 스크롤을 위한 스크립트
/// </summary>
public class BGScrolling : MonoBehaviour
{
    /// <summary>
    /// 이동 속도
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 무한 스크롤링을 위한 렌더러
    /// </summary>
    private Renderer materialRenderer;

    private void Awake()
    {
        // 렌더러를 가져온다.
        materialRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Scrolling();
    }

    /// <summary>
    /// 배경이 움직이는 것처럼 보이게 하는 함수
    /// </summary>
    private void Scrolling()
    {
        // 먼저 지역변수를 생성하고 이동속도를 부여해준다.
        float speed = moveSpeed * Time.deltaTime;
        // 그 다음 머테리얼에 있는 Offset을 이용해 마치 배경이 움직이는 것처럼 보이게 만들어준다.
        // 플레이어를 왼쪽에 배치해둘 예정이기에 배경이 오른쪽에서 왼쪽으로 이동하도록 해준다.
        materialRenderer.material.mainTextureOffset -= new Vector2(speed, 0);
    }
}
