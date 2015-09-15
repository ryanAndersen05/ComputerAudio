using UnityEngine;
using System.Collections;

public class ChannelHandler : MonoBehaviour {
	public int currentChannel;
	public CanvasRenderer[] channels;
	AudioHandler aHandler;

	void Start() {
		aHandler = GetComponent<AudioHandler> ();
		clearAllChannelColor ();
		setCurrentChannel (0);
	}

	public void setCurrentChannel(int newChannel) {
		int prevChannel = currentChannel;

		currentChannel = newChannel;
		if (prevChannel != newChannel) {
			aHandler.channelChanged(newChannel);
		}
		removeColorChannel (prevChannel);
		addColorChannel (currentChannel);
	}

	void clearAllChannelColor() {
		for (int i = 0; i < channels.Length; i++) {
			removeColorChannel(i);
		}
	}

	public void channelUp() {
		int newChannel = currentChannel - 1;
		//print (newChannel);
		if (newChannel < 0) {
			newChannel = channels.Length -1;
		}
		//print (newChannel);
		setCurrentChannel (newChannel);

	}

	public void channelDown() {
		int newChannel = currentChannel + 1;
		setCurrentChannel (newChannel % channels.Length);
	}

	void removeColorChannel(int i) {
		channels [i].SetColor (Color.grey);
	}

	void addColorChannel(int i) {
		channels [i].SetColor (Color.green);
	}


}
