using UnityEngine;

public class camaraController : MonoBehaviour
{
    public Transform player;

    public float limitLeft = -2;
    public float limitRight = 2;
    public float limitDown = -2;
    public float limitUp = 2;

    // Update is called once per frame
    void Update () {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x,limitLeft,limitRight),
                Mathf.Clamp(player.transform.position.y,limitDown,limitUp),transform.position.z);
    }
}
