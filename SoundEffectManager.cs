using UnityEngine;
using System.Collections.Generic;

namespace Holylib.SoundEffects
{
    public class SoundEffectManager : MonoBehaviour
    {
        public static SoundEffectManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                throw new System.Exception("An instance of this singleton already exists.");
            }
            else
            {
                Instance = this;
            }
        }

        public GameObject EmptySoundObject;

        public GameObject CreateSFXObj(GameObject EmptySoundObject)
        {
            return Instantiate(EmptySoundObject, null);
        }

        public void DestroySFXObject(GameObject SFXobject)
        {
            Destroy(SFXobject);
        }

        public List<GameObject> PlayinSounds;
    }

    
    public static class SoundEffectController
    {
        public static GameObject PlaySFX(SoundClip clip, bool isloop = false, float volume = 1, float playduration = -1, float startduration = -1,Vector3 pos = new Vector3(),bool isindipendent = false)
        {
            //Create SFX Object
            GameObject SoundEffectsObject = SoundEffectManager.Instance.CreateSFXObj(SoundEffectManager.Instance.EmptySoundObject);
            SoundEffectsObject.transform.position = pos;
            if (!isindipendent)
            {
                SoundEffectManager.Instance.PlayinSounds.Add(SoundEffectsObject);
            }
            

            //Create New SFX Data
            SoundEffect sfx = new SoundEffect();
            sfx.Clip = clip.Clip;
            sfx.isloop = isloop;
            sfx.volume = volume;
            sfx.playduration = playduration;
            sfx.startduration = startduration;
            sfx.pos = pos;

            SoundEffectsObject.GetComponent<SoundSource>().sfx = sfx;

            return SoundEffectsObject;
        }

        public static void StopSFX(GameObject SFXobject)
        {
            SoundEffectManager.Instance.PlayinSounds.Remove(SFXobject);
            SoundEffectManager.Instance.DestroySFXObject(SFXobject);
        }

        public static void StopAllSFX()
        {
            foreach(GameObject SFXobject in SoundEffectManager.Instance.PlayinSounds)
            {
                SoundEffectManager.Instance.DestroySFXObject(SFXobject);
            }
            SoundEffectManager.Instance.PlayinSounds.Clear();
        }
    }

    public class SoundEffect : MonoBehaviour
    {
        public AudioClip[] Clip;
        public bool isloop = false;
        public float volume = 1;
        public float playduration = -1;
        public float startduration = -1;
        public Vector3 pos = new Vector3(0,0,0);
    }
}
