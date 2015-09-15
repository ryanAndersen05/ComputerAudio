using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioHandler : MonoBehaviour {
	public AudioClip[] songs;
	public float volume;
	public Text audioInfo;

	AudioSource aSource;
	ChannelHandler channelHandler;
	bool fastForwarding;
	bool userPause;
	float currentTime;

	void Start() {
		channelHandler = GetComponent<ChannelHandler> ();
		aSource = GetComponent<AudioSource> ();
		aSource.clip = songs [channelHandler.currentChannel];
		userPause = true;

	}

	void Update() {
		updateAudioText ();
		checkChangeChannel ();
	}

	void checkChangeChannel() {
		if (!aSource.isPlaying && !userPause) {
			if (fastForwarding) {
				fastForward();
			}
			aSource.time = 0;
			channelHandler.channelDown();
			playMusic();
		}
	}


	public void channelChanged(int channelChanged) {
		float time = aSource.time;
		bool isPlaying = aSource.isPlaying;
		aSource.Stop ();
		aSource.clip = songs [channelChanged];
		if (time > aSource.clip.length) {
			aSource.time = 0;
		} else {
			aSource.time = time;
		}
		if (isPlaying) {
			playMusic();
		}
	}

	public void fastForward() {
		fastForwarding = !fastForwarding;
		if (fastForwarding) {
			aSource.pitch = 2;
		} else {
			aSource.pitch = 1;
		}
	}

	public void playMusic() {
		userPause = false;
		if (!aSource.isPlaying) {
			aSource.Play();
		}
	}

	public void pauseMusic() {
		if (aSource.isPlaying) {
			stopMusic ();
		} else {
			playMusic();
		}
	}

	public void stopMusic() {
		userPause = true;
		if (aSource.isPlaying) {
			float cTime = aSource.time;
			aSource.Stop();
			aSource.time = cTime;
		}
		if (fastForwarding) {
			fastForward();
		}
	}

	public void resetMusic() {
		aSource.time = 0;
	}

	void updateAudioText() {
		float currTime = aSource.time;
		int currMinutes = (int)(aSource.time / 60);
		currTime -= 60 * currMinutes;
		int totMinutes = (int)(aSource.clip.length / 60);
		float totSeconds = aSource.clip.length - (60 * totMinutes);
		//currTime = (int)(currTime * 100);
		//currTime /= 100;
		audioInfo.text = "Track Title: " + aSource.clip.name + "\n\n" + 
			"Playback Position: " + currMinutes + ":" + currTime.ToString ("00.00") + " / " + totMinutes + ":" + totSeconds.ToString ("00.00");
	}
}
