using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMRushStuckTriggerManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collect"))
        {
            ATMRushStuckMoneyManager.moneys.Add(other.gameObject);
            other.tag = "Collected";
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.AddComponent<ATMRushStuckTriggerManager>();
            Destroy(gameObject.GetComponent<ATMRushStuckTriggerManager>());
        }
    }
}
