using Mirror;
using UnityEngine;

public class PlayerGunController : NetworkBehaviour {

    [SerializeField] private Transform gun;
    [SerializeField] private Transform bulletSpawnPosition;

    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (isLocalPlayer) {
            HandleFiring();
            HandleMovement();
        }
    }

    private void HandleFiring() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Bullet.Create(bulletSpawnPosition.position, mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void HandleMovement() {
        Vector3 aimDirection = (mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        gun.eulerAngles = new Vector3(0, 0, angle - 90);
    }
}
