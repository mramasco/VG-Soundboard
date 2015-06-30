using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace Soundboard
{
    public class MediaPlayerWrapper
    {
        bool _loop;
        bool _replay;
        string _path;
        double _volume;
        double _masterVol;
        Dictionary<int, List<WaveOut>> _playingSounds = new Dictionary<int, List<WaveOut>>();

        public Guid Id {get;set;}
        public bool IsFinished {get;set;}

        public MediaPlayerWrapper(string path, double volume, bool loop, Guid guid)
        {
            Id = guid;
            _path = path;
            _loop = loop;
            _replay = false;
            _masterVol = 1;
            _volume = volume;
        }

        public void Play()
        {
          if (_loop)
          {
            _replay = true;
          }
          foreach (var device in Form1.PlayBackDevices)
          {
            try
            {
              var waveOutDevice = CreateNewSound(device);
              if (!_playingSounds.ContainsKey(device))
              {
                _playingSounds.Add(device, new List<WaveOut>());
              }
              _playingSounds[device].Add(waveOutDevice);
              waveOutDevice.Play();
            }
            catch (Exception)
            {
              CleanupSounds();
            }
           
          }

          
        }

      private void CleanupSounds()
      {
        foreach (var soundList in _playingSounds)
        {
          soundList.Value.RemoveAll(x => x.PlaybackState == PlaybackState.Stopped);
        }
      }

        void audioOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        {
          var waveout = sender as WaveOut;
          var deviceId = waveout.DeviceNumber;

          if (waveout != null) waveout.Dispose();
          foreach (var soundList in _playingSounds)
          {
            soundList.Value.RemoveAll(x => x.PlaybackState == PlaybackState.Stopped);
          }

          if (_loop && _replay)
          {
            try
            {
              var newSound = CreateNewSound(deviceId);
              _playingSounds[deviceId].Add(newSound);
              newSound.Play();
            }
            catch (Exception)
            {
              CleanupSounds();
             
            }
          
           
          }

       

        }

      private WaveOut CreateNewSound(int device)
      {
        WaveOut waveOutDevice;
        AudioFileReader audioFileReader;
        waveOutDevice = new WaveOut();
        audioFileReader = new AudioFileReader(_path);
        waveOutDevice.DeviceNumber = device;
        waveOutDevice.Init(audioFileReader);
        waveOutDevice.Volume = (float)(_volume * _masterVol);
        waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioOutput_PlaybackStopped);
        return waveOutDevice;
      }

        public void Stop()
        {
          foreach (var soundsList in _playingSounds)
          {
            foreach (var sound in soundsList.Value)
            {
              sound.Stop();
            }
          }
          _replay = false;
          IsFinished = true;
        }

        private void SetFinished(object sender, EventArgs e)
        {
            IsFinished = true;
        }

        public void ChangeVolume(double newVol)
        {
            _volume = newVol;
            foreach (var soundsList in _playingSounds)
            {
              foreach (var sound in soundsList.Value)
              {

                 sound.Volume = (float)(newVol * _masterVol);
              }
            }           
        }

      public void ChangeLoop(bool loop)
      {
        _loop = loop;
      }

        public void ChangeMasterVolume(double newVol)
        {
            _masterVol = newVol;
            foreach (var soundsList in _playingSounds)
            {
              foreach (var sound in soundsList.Value)
              {

                sound.Volume = (float) (newVol*_volume);
              }
            }
        }

        public double GetVolume()
        {
            return _volume;
        }
    }
}
