# Holylib.SoundEffects
My Sound Effect Library For Unity

Create an empty object and add SoundEffectManager script in it
then drag the SoundOBJ prefab into the SoundEffectManager 

now you can play any sound in any script by using Holylib.SoundEffects library

   using Holylib.SoundEffects;
   
   public SoundClip clip;
   
   SoundEffectController.PlaySFX(clip);
   
you can create SoundClip in assets by clicking Create/SoundClip
then drag the audio files into it;
