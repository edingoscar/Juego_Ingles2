using UnityEngine;

public class jugador : MonoBehaviour
{
    public Rigidbody2D rgb2d;
    public float velocidad = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        rgb2d.linearVelocity = new Vector2(directionX, directionY) * velocidad;
    }
}
