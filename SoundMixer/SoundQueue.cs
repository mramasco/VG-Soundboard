using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Media;

namespace Soundboard
{
    public class SoundQueue
    {
        List<MediaPlayerWrapper> players = new List<MediaPlayerWrapper>();

        public void PlaySound(Guid id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);

            if (player != null)
            {
            
                player.Play();
            }
        }

        public Guid RegisterSound(string path, double volume, bool loop)
        {
            var guid = Guid.NewGuid();
            MediaPlayerWrapper mpw = new MediaPlayerWrapper(path, volume, loop, guid);
            players.Add(mpw);
            return guid;
        }

        public void UnregisterSound(Guid id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);
            if (player != null)
            {
                player.Stop();
            }
 
            players.RemoveAll(x => x.Id == id);
        }

        public void StopAll()
        {
            foreach (var player in players)
            {
                player.Stop();
            }
        }

        public void SetMasterVolume(double vol)
        {
            
            foreach (var player in players)
            {
                player.ChangeMasterVolume(vol);
            }
        }

        public void SetVolume(double vol, Guid id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);

            if (player != null)
            {
                player.ChangeVolume(vol);
            }
        }

      public void SetLoop(bool loop, Guid id)
      {
        var player = players.FirstOrDefault(x => x.Id == id);

        if (player != null)
        {
          player.ChangeLoop(loop);
        }
      }

        public void ResetQueue()
        {
            players.Clear();
        }
    }
}
