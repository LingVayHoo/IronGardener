using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    public float Speed;
    private Vector3 move;

    void Start()
    {
        move = Vector3.forward;
    }


    void Update()
    {
        transform.Translate(move * Time.deltaTime * Speed);
    }
}
