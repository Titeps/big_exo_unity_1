using UnityEngine;

public class Wall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerControl playerControl = other.GetComponent<PlayerControl>();
            playerControl.transform.position = new Vector3(0,1,-100);
        }
    }
}
