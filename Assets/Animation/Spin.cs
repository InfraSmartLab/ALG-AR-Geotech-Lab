using UnityEngine;

public class Spin : MonoBehaviour
{
    // degrees per second
    public Vector3 degreesPerSecond = new Vector3(0f, 60f, 0f);

    void Update()
    {
        transform.Rotate(degreesPerSecond * Time.deltaTime, Space.Self);
    }
}
