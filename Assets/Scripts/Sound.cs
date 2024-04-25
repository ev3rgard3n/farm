using UnityEngine;
using UnityEngine.UI;


public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;
    private int _id = 0;


    private void Start()
    {
        PlayMucic(_id);
    }

    private void PlayMucic(int id)
    {
        _audioSource.clip = _audioClips[id];
        _audioSource.Play();
    }

    public void ChangeAudioSource()
    {
        if (_audioClips.Length - 1 > _id)
        {
            _id++;
        }
        else
        {
            _id = 0;   
        }
        Debug.Log(_id);
        PlayMucic(_id);
    }

}
