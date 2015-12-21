using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetupBgmSlider : MonoBehaviour {

    public Slider slider;
    void Start() {
        slider.onValueChanged.AddListener(x => AudioManager.instance.setBgmVolume(x));
    }
}