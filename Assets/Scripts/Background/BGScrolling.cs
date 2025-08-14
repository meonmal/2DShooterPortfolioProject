using UnityEngine;

/// <summary>
/// ����� ���� ��ũ���� ���� ��ũ��Ʈ
/// </summary>
public class BGScrolling : MonoBehaviour
{
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// ���� ��ũ�Ѹ��� ���� ������
    /// </summary>
    private Renderer materialRenderer;

    private void Awake()
    {
        // �������� �����´�.
        materialRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Scrolling();
    }

    /// <summary>
    /// ����� �����̴� ��ó�� ���̰� �ϴ� �Լ�
    /// </summary>
    private void Scrolling()
    {
        // ���� ���������� �����ϰ� �̵��ӵ��� �ο����ش�.
        float speed = moveSpeed * Time.deltaTime;
        // �� ���� ���׸��� �ִ� Offset�� �̿��� ��ġ ����� �����̴� ��ó�� ���̰� ������ش�.
        // �÷��̾ ���ʿ� ��ġ�ص� �����̱⿡ ����� �����ʿ��� �������� �̵��ϵ��� ���ش�.
        materialRenderer.material.mainTextureOffset -= new Vector2(speed, 0);
    }
}
