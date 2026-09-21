using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Tooltip("Décalage entre la caméra et la target selon axe z")]
    [SerializeField] float offset = 1;
    [SerializeField] Transform target;
   
    void Update()
    {
        float z = target.position.z + offset;
        Vector3 pos = transform.position;
        pos.z = z ;  
        transform.position = pos;     
    }
}

    
