using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    // Copy/pasted from Vickylance's comment on
    // https://answers.unity.com/questions/884250/how-to-make-the-camera-look-ahead-of-the-player-wh.html

    public float dampTime = 0.56f;
    public Transform target;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target)
        {
            Vector3 aheadPoint = target.position + new Vector3(target.GetComponent<Rigidbody2D>().velocity.x, target.GetComponent<Rigidbody2D>().velocity.y, 0);
            Vector3 point = Camera.main.WorldToViewportPoint(aheadPoint);
            Vector3 delta = aheadPoint - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }

}

