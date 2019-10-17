using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{
    Camera reticleCamera;

    [SerializeField]
    float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    [SerializeField]
    Vector2 maxPos;

    [SerializeField]
    Vector2 minPos;

    [SerializeField]
    bool usingMouse;

    // Start is called before the first frame update
    void Start()
    {
        reticleCamera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {

        Vector3 pos = transform.localPosition;
        pos.x = Mathf.Max(Mathf.Min(pos.x + Input.GetAxis("HorizontalPlayer") * Time.deltaTime * speed, maxPos.x), minPos.x);
        pos.y = Mathf.Max(Mathf.Min(pos.y + Input.GetAxis("VerticalPlayer") * Time.deltaTime * speed, maxPos.y), minPos.y);

        transform.localPosition = pos;
    }

}
