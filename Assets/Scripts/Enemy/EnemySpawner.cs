using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// �� �����ʰ� ��ȯ�� ��������
    /// ���� ���������̴� �迭�� �����Ѵ�.
    /// </summary>
    [SerializeField]
    private GameObject[] enemyPrefabs;

    /// <summary>
    /// �����ʰ� ��ȯ�� ���� �ִ� ����
    /// </summary>
    [SerializeField]
    private int enemySpawnCount;

    /// <summary>
    /// ��ȯ ����
    /// </summary>
    [SerializeField]
    private float spawnTime;

    /// <summary>
    /// �� �������� �ڽ��ݶ��̴�2D
    /// </summary>
    private BoxCollider2D boxcoll;

    private void Awake()
    {
        // BoxCollider2D�� �����´�.
        boxcoll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        // �Լ��� �ݺ��ؼ� �����ϴ�  InvokeRepeating�� ����Ѵ�.
        // �ڷ�ƾ�� ����ؼ� �ݺ��ص� ������
        // ���� ��ȯ�ϴ°� �ܼ� �ݺ��۾��̱⿡ �̰ɷ� ����.
        InvokeRepeating(nameof(EnemySpawn), 0f, spawnTime);
    }

    /// <summary>
    /// ���� ��ȯ�ϴ� �Լ�
    /// </summary>
    private void EnemySpawn()
    {
        // intŸ���� ���������� ������ ��, ���� �ʿ� �ִ� ������Ʈ�� �� Enemy�� �±׸� ���� ������ ã�Ƴ���.
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // ������ ���� ������Ʈ���� ������ enemySpawnCount���� ���ų� ���ٸ� �Լ� ���� ���
        if(currentEnemyCount >= enemySpawnCount)
        {
            return;
        }

        // Bounds�� ������Ʈ�� ������ ��Ÿ����. �ٸ� �̰� ����ҷ��� �ݶ��̴��� �������� �־�� �Ѵ�.
        Bounds bounds = boxcoll.bounds;

        // ������ ���� bounds�� ������Ʈ�� �ִ�, �ּ� x, y�� ������ �������� ���Ѵ�.
        float randomx = Random.Range(bounds.min.x, bounds.max.x);
        float randomy = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 spawnPos = new Vector2(randomx, randomy);

        // ���� �迭�� ����Ǿ��⿡ �������� enemy�� ������
        GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // ������ ����, ������ ��ġ���� ��ȯ�Ѵ�.
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
