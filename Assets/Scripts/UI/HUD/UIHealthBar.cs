using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private float _originalWidth;
    private float _midHealthThreshold;
    private float _lowHealthThreshold;

    public Color highHealthColor;
    public Color midHealthColor;
    public Color lowHealthColor;

    public static UIHealthBar Instance
    {
        get;
        private set;
    }

    public Image mask;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _originalWidth = mask.rectTransform.rect.width;
        _midHealthThreshold = _originalWidth / 2;
        _lowHealthThreshold = _originalWidth / 5;
        SetColor(_originalWidth);
    }

    public void SetValue(float value)
    {
        var newWidth = _originalWidth * value;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
        SetColor(newWidth);
    }

    private void SetColor(float width)
    {
        var image = GetComponent<Image>();
        if (width >= _midHealthThreshold)
            image.color = highHealthColor;
        else if (width <= _midHealthThreshold && width > _lowHealthThreshold)
            image.color = midHealthColor;
        else
            image.color = lowHealthColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
