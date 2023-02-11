using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Vfx : MonoBehaviour
{
    public GameObject clickedFx;
    public GameObject origin;
    
    public void SpawnClickedVFX()
    {
        if(clickedFx != null)
        {
            var vfx = Instantiate(clickedFx, origin.transform.position, Quaternion.identity) as GameObject;
            vfx.transform.SetParent(origin.transform);
            var ps = vfx.GetComponent<ParticleSystem>();
            Destroy(vfx, ps.main.duration + ps.main.startLifetime.constantMax);
        }
    }

}
