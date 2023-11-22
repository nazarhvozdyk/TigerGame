using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotation;

    private void LateUpdate()
    {
        transform.localEulerAngles += _rotation;
    }
}
