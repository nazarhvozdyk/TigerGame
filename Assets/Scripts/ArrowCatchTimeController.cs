using System.Collections;
using UnityEngine;

public class ArrowCatchTimeController : MonoBehaviour
{
    public delegate void OnCatchEndedCallBack();

    [SerializeField]
    private RectTransform _frameTransform;

    private float _startFrameScale = 1.5f;

    private void Start()
    {
        _frameTransform.gameObject.SetActive(false);
    }

    public void CreateCatchTime(
        ArrowRequest arrowRequest,
        float time,
        OnCatchEndedCallBack callBack
    )
    {
        _frameTransform.position = arrowRequest.transform.position;
        StartCoroutine(CatchTime(time, callBack));
    }

    public void RemoveCurrentCatchTime()
    {
        _frameTransform.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator CatchTime(float time, OnCatchEndedCallBack callBack)
    {
        _frameTransform.localScale = Vector3.one * _startFrameScale;
        _frameTransform.gameObject.SetActive(true);

        for (float t = 0; t < time; t += Time.deltaTime)
        {
            float process = t / time;
            float endFrameScale = 1f;
            float currentScale = Mathf.Lerp(_startFrameScale, endFrameScale, process);

            _frameTransform.localScale = Vector3.one * currentScale;

            yield return null;
        }

        _frameTransform.gameObject.SetActive(false);
        callBack();
    }
}
