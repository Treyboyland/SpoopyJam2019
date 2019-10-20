using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasController : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    Button buttonSelectedWhenShown;

    [SerializeField]
    Button buttonSelectedWhenHidden;

    [SerializeField]
    bool isHiddenByDefault;

    // Start is called before the first frame update
    void Start()
    {
        if (isHiddenByDefault)
        {
            canvas.gameObject.SetActive(false);
        }
        else
        {
            ShowCanvas();
        }
    }

    public void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
        if (buttonSelectedWhenShown != null)
        {
            buttonSelectedWhenShown.Select();
        }
    }

    public void HideCanvas()
    {
        canvas.gameObject.SetActive(false);
        if (buttonSelectedWhenHidden != null)
        {
            buttonSelectedWhenHidden.Select();
        }
    }
}
