using UnityEngine;
using System.Collections;

public class HolographicHUD : vp_SimpleHUD
{
    public GameObject GUIObject;
    
    private float safeHealth
    {
        get
        {
            float hp = m_Player.Health.Get() * 10;
            return hp > 2 ? hp : 3;
        }
    }

    protected override void OnGUI()
    {
    }

    void Start()
    {
        if(!base.ShowHUD)
        {
            GUIObject.SetActive(false);
        }
        else
        {
            StartCoroutine(UpdateGUI());
        }
    }

    IEnumerator UpdateGUI()
    {
        do
        {
            sliders.health = safeHealth;
            int maxAmmo = m_Player.CurrentWeaponMaxAmmoCount.Get();
            bullets.bullets_max = maxAmmo == 0 ? 30 : maxAmmo;
            bullets.bullets_n = m_Player.CurrentWeaponAmmoCount.Get();
            yield return new WaitForSeconds(0.2f);
        } while (true);
    }
}
