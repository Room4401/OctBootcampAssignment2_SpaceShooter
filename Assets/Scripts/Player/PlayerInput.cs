using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontal, vertical;
    private bool mouseInput;
    private Vector2 aimingPoint;
    private Player player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        aimingPoint = Input.mousePosition;

        if(player.BuffStatus())
        {
            mouseInput = Input.GetMouseButton(0);
        }
        else
        {
            mouseInput = Input.GetMouseButtonDown(0);
        }
        if (mouseInput)
        {
            player.Shoot();
        }
        if (Input.GetMouseButtonDown(1))
        {
            player.UseNuke();
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector2(horizontal, vertical), aimingPoint);
    }
}