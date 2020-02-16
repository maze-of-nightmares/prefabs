using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_siren_laser_action : MonoBehaviour
{
    public ParticleSystem trap_particle; // 재생할 함정 파티클
    public float trap_playTime; // 함정이 발동되는 시간
    public float trap_stopTime; // 함정이 멈춰있는 시간
    public GameObject siren;

    private Collider trap_collider;
    private bool is_trap = false;
    private trap_siren_action siren_script;

    // Start is called before the first frame update
    void Start()
    {
        trap_collider = GetComponent<Collider>();
        StartCoroutine(TrapEffect());
        siren_script = siren.GetComponent<trap_siren_action>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (is_trap)
        {
            Debug.Log("Dead");
            siren_script.SetWarning(true);
        }
    }

    private IEnumerator TrapEffect()
    {
        while (true)
        {
            is_trap = true;
            trap_particle.Play();
            yield return new WaitForSeconds(trap_playTime);

            is_trap = false;
            trap_particle.Stop();
            trap_particle.Clear();
            yield return new WaitForSeconds(trap_stopTime);
        }
    }
}
