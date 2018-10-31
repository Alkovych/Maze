using UnityEngine;
using System.Collections;

public class Rotate_wall : MonoBehaviour {

	void Update()
    {
        transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
    }
}
