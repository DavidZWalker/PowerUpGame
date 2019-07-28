using UnityEngine;
using System.Collections;

public class PrimaryWeaponBase : MonoBehaviour, IPrimaryWeapon
{
    private int _currentMag;
    private bool _isReady;
    private float _timerHelper_reload;
    private float _timerHelper_cooldown;
    private AudioSource _audioSource;
    private bool _isReloading;

    public float force = 200f;
    public float cooldownTime = 0.2f;
    public int magSize = 10;
    public float bulletSpread = 0.2f;
    public int reserveRounds = -1; // negative value = infinite
    public float reloadTime = 2f;
    public GameObject bulletPrefab;
    public AudioClip gunshotAudio;
    public AudioClip reloadAudio;

    public bool IsReloading
    {
        get => _isReloading;
        private set
        {
            if (_isReloading != value)
            {
                _isReloading = value;
                if (value)
                    _audioSource.PlayOneShot(reloadAudio);
                else if (_audioSource.isPlaying)
                    _audioSource.Stop();
            }
                
        }
    }

    public void Fire(Vector2 position, Vector2 direction)
    {
        if (bulletPrefab != null)
        {
            if (_currentMag > 0 && !IsReloading)
            {
                if (_isReady)
                {
                    var spreadX = Random.Range(-bulletSpread, bulletSpread);
                    var spreadY = Random.Range(-bulletSpread, bulletSpread);
                    var adjustedDirection = new Vector2(direction.x + spreadX, direction.y + spreadY).normalized;
                    _isReady = false;
                    var projectileObj = Instantiate(bulletPrefab, position + adjustedDirection * 0.5f, gameObject.transform.rotation);
                    var bullet = projectileObj.GetComponent<IProjectile>();
                    bullet.Launch(adjustedDirection, force);
                    _audioSource.PlayOneShot(gunshotAudio);
                    _currentMag--;
                    UIMagInfo.Instance.SetPrimaryWeaponMagInfo(_currentMag, reserveRounds);
                    if (_currentMag == 0)
                        Reload();
                }
            }
            else
                Reload();
        }
    }

    public void Reload()
    {
        if (_currentMag < magSize)
        IsReloading = true;
    }

    // Use this for initialization
    void Start()
    {
        _currentMag = magSize;
        _isReady = true;
        _audioSource = GetComponent<AudioSource>();
        UIMagInfo.Instance.SetPrimaryWeaponMagInfo(_currentMag, reserveRounds);
        UIReloadBar.Instance.SetValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        // get reload button press
        if (!IsReloading && Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        // do reload
        if (IsReloading)
        {
            _timerHelper_reload += Time.deltaTime;
            UIReloadBar.Instance.SetValue(_timerHelper_reload / reloadTime);
            if (_timerHelper_reload >= reloadTime)
            {
                _timerHelper_reload = 0;
                IsReloading = false;
                _currentMag = magSize;
                UIMagInfo.Instance.SetPrimaryWeaponMagInfo(_currentMag, reserveRounds);
                UIReloadBar.Instance.SetValue(0);
            }
        }

        // do cooldown
        if (!_isReady)
        {
            _timerHelper_cooldown += Time.deltaTime;
            if (_timerHelper_cooldown >= cooldownTime)
            {
                _isReady = true;
                _timerHelper_cooldown = 0;
            }
        }
    }
}
