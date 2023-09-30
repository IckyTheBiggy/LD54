using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    void Update()
    {
        transform.position = _target.position;
    }
}
