using Mirror;
using UnityEngine;

public class PlayerMovementController : NetworkBehaviour {

    [SerializeField] private float speed;

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        if (isLocalPlayer) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(
                moveHorizontal * speed,
                moveVertical * speed,
                0
            );
            transform.position += movement * Time.deltaTime;
        }
    }
}
