using System.Collections.Generic;
using UnityEngine;

using System.Collections;

public class Platform : MonoBehaviour
{
    public static List<Platform> Platforms = new List<Platform>(); 
    [SerializeField]
    private Vector3 _jumpTo = new Vector3();

    public Vector3 JumpTo
    {
        get
        {
            return transform.position + _jumpTo;
        }
    }

    void Awake()
    {
        Platforms.Add(this);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        Platforms.Remove(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + _jumpTo, 1.0f);
    }
}
