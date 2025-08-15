using UnityEngine;

/// <summary>
/// �÷��̾��� ��Ʈ���� ����ϴ� ��ũ��Ʈ.
/// �̵�, ���ݵ��� ���⿡�� ó���Ѵ�.
/// </summary>
public class PlayerControll : MonoBehaviour
{
    /// <summary>
    /// �÷��̾��� �̵��ӵ�
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// �÷��̾� �Ѿ� ������
    /// </summary>
    [SerializeField]
    private GameObject bulletPrefab;

    /// <summary>
    /// �Ѿ� ��ȯ ��ġ
    /// </summary>
    [SerializeField]
    private Transform spawnPosition;

    /// <summary>
    /// �߻� ��Ÿ��
    /// </summary>
    [SerializeField]
    private float coolTime;

    /// <summary>
    /// �÷��̾��� ������ٵ�2D
    /// </summary>
    private Rigidbody2D rigid;

    /// <summary>
    /// �� ���� ��Ÿ��
    /// </summary>
    private float nextTime;

    private void Awake()
    {
        // ������ٵ�2D ��������
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // �Ѿ��� �߻��ϴ� �Լ��� FixedUpdate�� ������
        // ������ ������ �߻�ȴ�.
        Shoot();
    }

    /// <summary>
    /// �����ϰ� �����̰� ����� ���� �׳� Update�� �ƴ� FixedUpdate�� �̿��� �����̰� �����.
    /// </summary>
    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// �÷��̾��� �̵��� ����ϴ� ��ũ��Ʈ
    /// </summary>
    private void Movement()
    {
        // ����� ������ �Է°��� ���Ѵ�.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // ������ ���� ������ ����ȭ�Ͽ� �������� pos�� �־��ְ�
        Vector2 pos = new Vector2(horizontal, vertical).normalized;
        // Rigidbody2D�� �̿��� moveSpeed��ŭ�� �ӵ��� �����̰� �Ѵ�.
        rigid.linearVelocity = pos * moveSpeed;

        // Vector3Ÿ���� ���������� ������
        Vector3 position = transform.position;
        // Mathf.Clamp�� �̿��� �ּ� �ִ� �̵� ������ �����Ѵ�.
        position.x = Mathf.Clamp(position.x, -9f, 9f);
        position.y = Mathf.Clamp(position.y, -5f, 5f);
        transform.position = position;
    }

    /// <summary>
    /// �÷��̾ �Ѿ��� �߻��ϰ� ����� �Լ�
    /// </summary>
    private void Shoot()
    {
        // ��Ÿ���� ������ �ʾ����� �Լ��� �������� �ʴ´�.
        if(Time.time < nextTime)
        {
            return;
        }

        // z�� ���콺 ���� ��ư�� ������ ������ ����
        if(Input.GetKey(KeyCode.Z) || Input.GetMouseButton(0))
        {
            PlayerState playerState = GetComponent<PlayerState>();
            // �Ѿ� ��ȯ(�Ѿ� �������� ��ȯ ��ġ��, ȸ�� ���� ��ȯ�Ѵ�.)
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition.position, Quaternion.identity);
            bullet.GetComponent<PlayerBullet>().SetDamage(playerState.Damage);

            // ���� �߻�ð� ����
            nextTime = Time.time + coolTime;
        }
    }
}
