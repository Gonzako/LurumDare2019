using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "AudioClipGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "AudioClipEvent",
	    order = 120)]
	public sealed class AudioClipGameEvent : GameEventBase<AudioClip>
	{
	}
}