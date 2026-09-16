using UnityEngine;

public class FollowCam : MonoBehaviour
{
    
    [SerializeField] float offset = 1;
    [SerializeField] Transform target;
   
    void Update()
    {
        float z = target.position.z - offset;
        Vector3 pos = transform.position;
        pos.z = z ;  
        transform.position = pos;     
    }
}

    
