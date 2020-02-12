using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_niddle_action : MonoBehaviour
{
    public float max_height; // 최고 도달점
    public float min_height; // 최저 도달점
    public float velocity; // 움직이는 속도
    public GameObject niddle;
    
    private bool isUP = true; // 올라가고 있는지 내려가고 있는지
    private bool isWait = false;
    private Collider niddle_collider;
    private float start_velocity;
    private Transform niddle_position;

    // Start is called before the first frame update
    void Start()
    {
        niddle_collider = GetComponent<Collider>();
        niddle_position = niddle.transform;
        start_velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUP)
        {
            niddle_position.position = Vector3.Lerp(niddle_position.position, 
            max_height * Vector3.up, velocity * Time.deltaTime);

            float distance = max_height - niddle_position.position.y;

            if (distance < float.Epsilon + 0.01f)
            {
                isUP = false;
            }
        }
        else
        {
            niddle_position.position = Vector3.MoveTowards(niddle_position.position,
                min_height * Vector3.up, velocity * Time.deltaTime);

            float distance = niddle_position.position.y - min_height;

            if (distance < float.Epsilon + 0.01f)
            {
                if (!isWait)
                    StartCoroutine(WaitTime());
            }
        }
    }

    IEnumerator WaitTime()
    {
        isWait = true;
        yield return new WaitForSeconds(5f);
        isUP = true;
        isWait = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isWait)
            Debug.Log("Dead");
    }
}

