using UnityEngine;

public class Tiger : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        InputController.Instance.onInput += OnInput;
    }

    public void OnInput(ArrowCode code)
    {
        if (code == ArrowCode.Up)
            Move(1, false);
        else if (code == ArrowCode.Down)
            Move(0, false);
        else if (code == ArrowCode.Right)
            Move(1, true);
        else if (code == ArrowCode.Left)
            Move(0, true);
    }

    private void Move(int direction, bool isHorizontal)
    {
        direction = Mathf.Clamp(direction, -1, 1);

        if (isHorizontal)
        {
            if (direction == 1)
                _animator.SetTrigger("rollToTheLeft");
            else
                _animator.SetTrigger("rollToTheRight");
        }
        else
        {
            if (direction == 1)
                _animator.SetTrigger("riseOnBackLegs");
            else
                _animator.SetTrigger("layDown");
        }
    }
}
