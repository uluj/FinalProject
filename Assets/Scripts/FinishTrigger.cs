using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Car")
        {
            GameManager.level++;
            GameManager.instance.winScreen.SetActive(true);
        }
    }
}
