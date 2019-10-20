using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{

    static SoundController _instance;

    public static SoundController Controller
    {
        get
        {
            return _instance;
        }
    }

    AudioSource oneShotAudioSource;

    [SerializeField]
    List<ClipWithVolume> skeletonDeathClips;

    [SerializeField]
    List<ClipWithVolume> skeletonHurtClips;

    [SerializeField]
    List<ClipWithVolume> playerHurtClips;

    [SerializeField]
    List<ClipWithVolume> newRoundClips;

    [SerializeField]
    List<ClipWithVolume> shootClips;

    [SerializeField]
    List<ClipWithVolume> powerupClips;

    [SerializeField]
    List<ClipWithVolume> clipEmptyClips;

    [SerializeField]
    List<ClipWithVolume> reloadWeaponClips;

    public PlaySkeletonDeathSound OnPlaySkeletonDeathSound;
    public PlaySkeletonHurtSound OnPlaySkeletonHurtSound;
    public PlayPlayerHurtSound OnPlayPlayerHurtSound;
    public PlayShootSound OnPlayShootSound;
    public PlayNewRoundSound OnPlayNewRoundSound;
    public PlayPowerupSound OnPlayPowerupSound;
    public PlayClipEmptySound OnPlayClipEmptySound;

    public PlayReloadWeaponSound OnPlayReloadWeaponSound;

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        OnPlaySkeletonDeathSound.AddListener(() =>
        {
            PlayRandomSound(skeletonDeathClips);
        });

        OnPlaySkeletonHurtSound.AddListener(() =>
        {
            PlayRandomSound(skeletonHurtClips);
        });

        OnPlayShootSound.AddListener(() =>
        {
            PlayRandomSound(shootClips);
        });

        OnPlayNewRoundSound.AddListener(() =>
        {
            PlayRandomSound(newRoundClips);
        });

        OnPlayPowerupSound.AddListener(() =>
        {
            PlayRandomSound(powerupClips);
        });

        OnPlayClipEmptySound.AddListener(() =>
        {
            PlayRandomSound(clipEmptyClips);
        });

        OnPlayPlayerHurtSound.AddListener(() =>
        {
            PlayRandomSound(playerHurtClips);
        });

        OnPlayReloadWeaponSound.AddListener(() =>
        {
            PlayRandomSound(reloadWeaponClips);
        });

        oneShotAudioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound(List<ClipWithVolume> clips)
    {
        if (clips.Count != 0)
        {
            var cv = clips[UnityEngine.Random.Range(0, clips.Count)];
            oneShotAudioSource.PlayOneShot(cv.Clip, cv.Volume);
        }
    }

}
