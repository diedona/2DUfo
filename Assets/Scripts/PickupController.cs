using UnityEngine;

public class PickupController : MonoBehaviour
{

    public Transform _transform;
    public int Points
    {
        get;
        private set;
    }
    public bool TransformationDone;

    private Vector3 currentScale;
    private Vector3 desiredScale;
    private float speed = 2;
    private float rotation;

    // Use this for initialization
    void Start()
    {
        _transform = GetComponent<Transform>();
        Points = Random.Range(1, 4);
        rotation = Random.Range(25, 45);
        desiredScale = new Vector3(Points, Points, 1);
        currentScale = this.transform.localScale;
        TransformationDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);

        if(this.TransformationDone)
        {
            // HALTS
            return;
        }

        currentScale = Vector3.Lerp(currentScale, desiredScale, speed * Time.deltaTime);
        _transform.localScale = currentScale;

        // DID IT REACH THE DESIRED?
        if(_transform.localScale == desiredScale)
        {
            this.TransformationDone = true;
        }
    }
}
