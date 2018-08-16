using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class was needed to ensure music did not restart between scenes. This allows music to play seemlessly
/// </summary>
public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
}
