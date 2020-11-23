using UnityEngine;

public class StarTrail : MonoBehaviour
{
    public ParticleSystem sparklyParticleSystem = null;
    [SerializeField] private AudioClip trailSound = null;
    private Vector3 screenPoint;
    private Vector3 lastMousePosition = Vector3.zero;
    private const float timeToReachTarget = 0.2f;
    private float t = 0;
    private bool isStopped = true;
    private int frameCounter = 0;

    private void Start()
    {
        sparklyParticleSystem.Stop();
    }

    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;

        frameCounter++;
        if (lastMousePosition != Input.mousePosition)
        {
            t = 0;
            lastMousePosition = Input.mousePosition;
            if (isStopped)
            {
                isStopped = false;
                sparklyParticleSystem.Play();
            }

            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            if (frameCounter >= 200)
            {
                frameCounter = 0;
                AudioController.Instance.PlayRandomSfx(trailSound);
            }
        }
        else
        {
            if(sparklyParticleSystem.isPlaying && t >= timeToReachTarget)
            {
                isStopped = true;
                sparklyParticleSystem.Stop();
            }
        }
        lastMousePosition = Input.mousePosition;


    }
}
