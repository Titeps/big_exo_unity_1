using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FinishLine : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerControl playerControl = other.GetComponent<PlayerControl>();
            playerControl.speed = 0;
        }
    }
}
