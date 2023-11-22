using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadingProcessDisplay : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private TextMeshProUGUI _persentText;

    private void Start() { }

    private IEnumerator ShowProcess()
    {
        AsyncOperation loadingOperation = SceneController.AsyncSceneLoadOperation;

        while (loadingOperation.isDone)
        {
            float process = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            _persentText.text = (process * 100).ToString() + "%";
            _slider.value = process;

            yield return null;
        }
    }
}
