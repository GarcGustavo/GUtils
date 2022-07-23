using System.Linq;
using UnityEngine;

namespace _Project.Common
{
	[CreateAssetMenu(fileName = "NewAudioManager", menuName = "ScriptableObjects/Managers/AudioManager", order = 0)]
	public class AudioManager : ScriptableObject
	{
		public AudioClip[] sfxClips;
		public AudioClip[] bgmClips;
		public AudioSource audioSource;
		
		public void PlayAudio(string clip_name)
		{
			audioSource.clip = sfxClips.FirstOrDefault(x => x.name == clip_name);
			audioSource.Play();
		}
		
		public void PlayBGM(string clip_name)
		{
			audioSource.clip = bgmClips.FirstOrDefault(x => x.name == clip_name);
			audioSource.loop = true;
			audioSource.Play();
		}
		
	}
}