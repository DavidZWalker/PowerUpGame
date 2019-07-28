using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private float _originalWidth;
    private float _midHealthThreshold;
    private float _lowHealthThreshold;

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
            image.color = Color.white;
        else if (width <= _midHealthThreshold && width > _lowHealthThreshold)
            image.color = Color.yellow;
        else
            image.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
