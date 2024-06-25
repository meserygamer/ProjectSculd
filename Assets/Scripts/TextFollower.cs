using UnityEngine;


public class TextFollower : MonoBehaviour
{

    [SerializeField] private Transform m_LookAt;


    void Update()
    {
        transform.LookAt(m_LookAt);
    }
}
