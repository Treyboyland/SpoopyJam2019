using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{
    Camera reticleCamera;

    [SerializeField]
    PlayerName playerName;

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
        SetReticleSettings();
    }

    void SetReticleSettings()
    {
        if ((GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_MOUSE ||
            GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_KEYBOARD) && playerName != PlayerName.PLAYER_ONE)
        {
            this.Deactivate();
            return;
        }

        usingMouse = GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_MOUSE;
        //TODO: How would this work on mobile?
    }



    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (usingMouse)
        {
            HandleInputMouse();
        }
        else
        {
            HandleInputKeyboard();
        }
    }

    void HandleInputKeyboard()
    {
        Vector3 pos = transform.localPosition;
        pos.x = Mathf.Max(Mathf.Min(pos.x + PlayerInputs.GetValueForHoriztontalAxis(GameConstants.PlayerCount, playerName) * Time.deltaTime * speed, maxPos.x), minPos.x);
        pos.y = Mathf.Max(Mathf.Min(pos.y + PlayerInputs.GetValueForVerticalAxis(GameConstants.PlayerCount, playerName) * Time.deltaTime * speed, maxPos.y), minPos.y);

        transform.localPosition = pos;
    }

    void HandleInputMouse()
    {
        var pos = Input.mousePosition;
        pos.z = 2;
        transform.position = reticleCamera.ScreenToWorldPoint(pos);
    }
}
