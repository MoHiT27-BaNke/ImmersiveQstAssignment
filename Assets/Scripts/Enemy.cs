using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int myPoints;
    public AudioClip mySoundClip;
    public bool isKilled;
    private void OnMouseDown()
    {
        if (!isKilled && GetComponent<Outline>()==null)
        {
            Outline myClickEffect = gameObject.AddComponent<Outline>();
            myClickEffect.OutlineWidth = 7;
            myClickEffect.OutlineColor = Color.yellow;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isKilled && collision.gameObject.tag == "Player")
        {
            isKilled = true;

            Destroy(GetComponent<Outline>());
            GetComponent<MeshRenderer>().material = UIManager.instance.killedMaterial;
            UIManager.instance.UpdateScoreUI(myPoints);
            UIManager.instance.PlayeAudio(mySoundClip);
        }
    }
}
