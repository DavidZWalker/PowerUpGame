using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReloadBar : MonoBehaviour
{
    private float _originalWidth;
    private Image _image;

    public static UIReloadBar Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void SetValue(float value)
    {
        var newWidth = _originalWidth * value;
        _image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _originalWidth = _image.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
