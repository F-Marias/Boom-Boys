using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform transform;
        public float speed;
    }

    public ParallaxLayer[] parallaxLayers;
    public float repeatOffset = 20.0f; // Adjust this to control when the layers start repeating

    void Update()
    {
        for (int i = 0; i < parallaxLayers.Length; i++)
        {
            float parallax = Time.deltaTime * parallaxLayers[i].speed;
            float layerTargetPosX = parallaxLayers[i].transform.position.x + parallax;
            Vector3 layerTargetPos = new Vector3(layerTargetPosX, parallaxLayers[i].transform.position.y, parallaxLayers[i].transform.position.z);
            parallaxLayers[i].transform.position = Vector3.Lerp(parallaxLayers[i].transform.position, layerTargetPos, Time.deltaTime);

            // Check if the layer has exited the background layer
            if (parallaxLayers[i].transform.position.x > repeatOffset)
            {
                // Move the layer back to the left to repeat the effect
                parallaxLayers[i].transform.position = new Vector3(parallaxLayers[i].transform.position.x - repeatOffset * 2, parallaxLayers[i].transform.position.y, parallaxLayers[i].transform.position.z);
            }
        }
    }
}
