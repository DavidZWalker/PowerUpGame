using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeaponController : MonoBehaviour
{
    private readonly int MOUSEBUTTON_LEFT = 0;
    private IPrimaryWeapon _selectedWeapon;

    void Start()
    {
        if (_selectedWeapon == null)
            SetWeapon(GetComponentInChildren<IPrimaryWeapon>());
    }

    // Update is called once per frame
    void Update()
    {
        if (_selectedWeapon != null && Input.GetMouseButtonDown(MOUSEBUTTON_LEFT))
            _selectedWeapon.Fire(
                transform.position, 
                GetComponentInChildren<PlayerLookDirectionController>().GetLookDirection());
    }

    public void SetWeapon(IPrimaryWeapon weapon)
    {
        _selectedWeapon = weapon;
    }
}
