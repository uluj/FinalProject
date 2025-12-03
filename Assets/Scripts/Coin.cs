using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Car")
        {
            int speed = (int)other.GetComponent<Rigidbody>().velocity.magnitude * 5;
            int points = speed * 5;
            GameManager.instance.points += points;
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 1, 0);
    }
}
