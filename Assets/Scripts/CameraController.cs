using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _player;
    public float _cameraSpeed = 6;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player");
        offset = this.transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.moveCamera();
    }

    private void moveCamera()
    {
        Vector3 pos = (_player.transform.position + offset);
        this.transform.position = Vector3.Lerp(this.transform.position, pos, _cameraSpeed * Time.deltaTime);
    }
}
