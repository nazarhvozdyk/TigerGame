using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    [SerializeField]
    private Behaviour _behaviour;

    private void Start()
    {
        _behaviour.enabled = false;
    }
}
