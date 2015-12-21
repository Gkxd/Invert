using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetupSfxSlider : MonoBehaviour {

    public Slider slider;
    void Start() {
        slider.onValueChanged.AddListener(x => AudioManager.instance.setSfxVolume(x));
    }
}