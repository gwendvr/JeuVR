using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnigme : MonoBehaviour
{
    [SerializeField] private List<TriggerArea> triggers = new List<TriggerArea>();
    private bool isValid = false;
    public void Verify()
    {
        if (triggers[0].battery != null && 
            triggers[1].battery != null && 
            triggers[2].battery != null && 
            triggers[3].battery != null)
        {
            if(triggers[0].battery.batteryID == 1 && 
                triggers[1].battery.batteryID == 2 && 
                triggers[2].battery.batteryID == 3 && 
                triggers[3].battery.batteryID == 4)
            {
                isValid = true;
            }
        }
    }
}
