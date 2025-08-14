using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// 적 스포너가 소환할 적프리팹
    /// 적이 여러마리이니 배열로 선언한다.
    /// </summary>
    [SerializeField]
    private GameObject[] enemyPrefabs;

    /// <summary>
    /// 스포너가 소환할 적의 최대 갯수
    /// </summary>
    [SerializeField]
    private int enemySpawnCount;

    /// <summary>
    /// 소환 간격
    /// </summary>
    [SerializeField]
    private float spawnTime;

    /// <summary>
    /// 적 스포너의 박스콜라이더2D
    /// </summary>
    private BoxCollider2D boxcoll;

    private void Awake()
    {
        // BoxCollider2D를 가져온다.
        boxcoll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        // 함수를 반복해서 실행하는  InvokeRepeating를 사용한다.
        // 코루틴을 사용해서 반복해도 되지만
        // 적을 소환하는건 단순 반복작업이기에 이걸로 쓴다.
        InvokeRepeating(nameof(EnemySpawn), 0f, spawnTime);
    }

    /// <summary>
    /// 적을 소환하는 함수
    /// </summary>
    private void EnemySpawn()
    {
        // int타입의 지역변수를 선언한 후, 현재 맵에 있는 오브젝트들 중 Enemy의 태그를 가진 적들을 찾아낸다.
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // 위에서 구한 오브젝트들의 갯수가 enemySpawnCount보다 많거나 같다면 함수 실행 취소
        if(currentEnemyCount >= enemySpawnCount)
        {
            return;
        }

        // Bounds는 오브젝트의 영역을 나타낸다. 다만 이걸 사용할려면 콜라이더나 렌더러가 있어야 한다.
        Bounds bounds = boxcoll.bounds;

        // 위에서 만든 bounds로 오브젝트의 최대, 최소 x, y의 랜덤한 영역값을 구한다.
        float randomx = Random.Range(bounds.min.x, bounds.max.x);
        float randomy = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 spawnPos = new Vector2(randomx, randomy);

        // 적이 배열로 선언되었기에 지역변수 enemy를 생성후
        GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // 랜덤한 적을, 랜덤한 위치에서 소환한다.
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
