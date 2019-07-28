using UnityEngine;
using System.Collections;
using TMPro;

public class UIMagInfo : MonoBehaviour
{
    public static UIMagInfo Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void SetPrimaryWeaponMagInfo(int currentMag, int reserveRounds)
    {
        string reserveRoundsTxt = reserveRounds < 0 ? "\u221E" : reserveRounds.ToString();
        var magInfoText = GetComponent<TextMeshProUGUI>();
        magInfoText.text = currentMag + " / " + reserveRoundsTxt;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
