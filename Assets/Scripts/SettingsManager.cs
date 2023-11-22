using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private Image _musicTougleImage;

    [SerializeField]
    private Image _soundTougleImage;

    [SerializeField]
    private Sprite _offTougleSprite;

    [SerializeField]
    private Sprite _onTougleSprite;

    [SerializeField]
    private AudioMixer _musicAudioMixer;

    public void OnMusicTougleValueChanged(bool value)
    {
        float testValue = 0;
        _musicAudioMixer.GetFloat("Volume", out testValue);

        if (value)
        {
            _musicAudioMixer.SetFloat("Volume", 0f);
            _musicTougleImage.sprite = _onTougleSprite;
        }
        else
        {
            _musicAudioMixer.SetFloat("Volume", 80f);
            _musicTougleImage.sprite = _offTougleSprite;
        }
    }

    public void OnSoundTougleValueChanged(bool value)
    {
        if (value)
            _soundTougleImage.sprite = _onTougleSprite;
        else
            _soundTougleImage.sprite = _offTougleSprite;

        AudioListener.pause = !value;
    }
}
