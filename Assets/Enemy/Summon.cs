using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    Vector3 pos;

    Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        Transform transform = GetComponent<Transform>();
        pos = new Vector3();
        pos = transform.position;
        rot = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        transform.position = pos;
        transform.rotation = rot;
    }
}
