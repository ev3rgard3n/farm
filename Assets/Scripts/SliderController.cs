using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.LevelChanged += SetLevel;
    }

    private void OnDisable()
    {
        _player.LevelChanged -= SetLevel;
    }

    public void SetLevel()
    {
        _slider.value = _player.Level;
    }
}
