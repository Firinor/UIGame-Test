using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private AudioMixerGroup audioMixerGroup;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Sprite[] spritesLibrary;
    [SerializeField]
    private Image backgroundImage;
    [SerializeField]
    private Image effectsImage;

    public void BackgroundSwitch()
    {
        audioMixerGroup.audioMixer.GetFloat("background", out float volume);
        if (volume == 0)
            BackgroundOff();
        else
            BackgroundOn();
        audioSource.Play();
    }
    public void EffectsSwitch()
    {
        audioMixerGroup.audioMixer.GetFloat("effects", out float volume);
        if (volume == 0)
            EffectsOff();
        else
            EffectsOn();
        audioSource.Play();
    }

    private void BackgroundOff()
    {
        audioMixerGroup.audioMixer.SetFloat("background", -80);
        backgroundImage.sprite = Resources.Load<Sprite>("Textures/settings/musicOff");
    }
    private void BackgroundOn()
    {
        audioMixerGroup.audioMixer.SetFloat("background", 0);
        backgroundImage.sprite = Resources.Load<Sprite>("Textures/settings/musicOn");
    }
    private void EffectsOff()
    {
        audioMixerGroup.audioMixer.SetFloat("effects", -80);
        effectsImage.sprite = Resources.Load<Sprite>("Textures/settings/effectsOff");
    }
    private void EffectsOn()
    {
        audioMixerGroup.audioMixer.SetFloat("effects", 0);
        effectsImage.sprite = Resources.Load<Sprite>("Textures/settings/effectsOn");
    }
}
