using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}
