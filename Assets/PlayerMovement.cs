using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public int MovementSpeed { get; set; } = 7;
    public int JumpPower { get; set; } = 14;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(xMovement * MovementSpeed, rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rigidbody.velocity.x, JumpPower);
        }
    }
}
