using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] private Transform batteryPosition;
    public BatteryData battery;
    [SerializeField] CheckEnigme enigmeManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Battery"))
        {
            other.gameObject.transform.position = batteryPosition.position;
            other.gameObject.transform.rotation = batteryPosition.rotation;
            Rigidbody rb = other.GetComponent<Rigidbody>();
            battery = other.GetComponent<BatteryData>();
            rb.isKinematic = true;
            enigmeManager.Verify();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            battery = null;
            rb.isKinematic = false;
        }
    }
}
