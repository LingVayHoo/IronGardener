using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.Jump();
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.GetDown();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            player.GetUp();
        }
    }
}
