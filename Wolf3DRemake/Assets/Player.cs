using UnityEngine;

public class Player : MonoBehaviour
{
    bool lmb = false;

    public float gunDistance = 200f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lmb = true;
        }
    }

    void FixedUpdate()
    {
        if (lmb)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, gunDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow, 5f);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("Hit an enemy!");
                }
            }
            lmb = false;
        }
    }
}
