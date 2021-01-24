using Mirror;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public static Bullet Create(Vector3 spawnPosition, Vector3 targetPosition) {
        Transform pfBullet = Resources.Load<Transform>("pfBullet");
        Transform bulletTransform = Instantiate(pfBullet, spawnPosition, Quaternion.identity);

        Bullet bullet = bulletTransform.GetComponent<Bullet>();
        Vector3 normalizedDirection = targetPosition - spawnPosition;

        bullet.normalizedDirection = new Vector3(normalizedDirection.x, normalizedDirection.y, 0f).normalized;
        NetworkServer.Spawn(bullet.gameObject);

        return bullet;
    }

    [SerializeField] private float speed;
    private Vector3 normalizedDirection;

    [SerializeField] private float despawnTimerMax;
    private float despawnTimer;

    private void Awake() {
        despawnTimer = despawnTimerMax;
    }

    private void Update() {
        transform.position += normalizedDirection * speed * Time.deltaTime;

        despawnTimer -= Time.deltaTime;
        if (despawnTimer < 0f) {
            Destroy(gameObject);
        }
    }
}
