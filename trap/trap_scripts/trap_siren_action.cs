using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_siren_action : MonoBehaviour
{
    private Animator siren_light;
    public float trap_playTime;

    // Start is called before the first frame update
    void Start()
    {
        siren_light = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void SetWarning(bool warning)
    {
        siren_light.SetBool("isWarning", warning);
        StartCoroutine(SirenEffect());
    }

    IEnumerator SirenEffect()
    {
        yield return new WaitForSeconds(trap_playTime);
        siren_light.SetBool("isWarning", false);
    }
}
