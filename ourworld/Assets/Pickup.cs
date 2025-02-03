using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pickup : MonoBehaviour
{
    private UIscore a;
    private void Start()
    {
        a = GameObject.Find("a").GetComponent<UIscore>();
    }
    void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        a.addScore();
        Destroy(gameObject);
    }
}
