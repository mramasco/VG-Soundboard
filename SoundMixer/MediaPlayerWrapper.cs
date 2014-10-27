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
        bool _isLooping;
        string _path;
        double _volume;
        double _masterVol;
        Dictionary<int, WaveOut> PlayingSounds = new Dictionary<int, WaveOut>();

        public Guid Id {get;set;}
        public bool IsFinished {get;set;}

        public MediaPlayerWrapper(string path, double volume, bool loop, Guid guid)
        {
            Id = guid;
            _path = path;
            _loop = loop;
            _isLooping = false;
            _masterVol = 1;
            _volume = volume;
        }

        public void Play()
        {
            foreach (var device in Form1.PlayBackDevices)
            {
                if (!PlayingSounds.ContainsKey(device))
                {
                    WaveOut waveOutDevice;
                    AudioFileReader audioFileReader;
                    waveOutDevice = new WaveOut();
                    audioFileReader = new AudioFileReader(_path);
                    waveOutDevice.DeviceNumber = device;
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Volume = (float)(_volume * _masterVol);
                    waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioOutput_PlaybackStopped);
                    PlayingSounds.Add(device, waveOutDevice);

                }
                    PlayingSounds[device].Stop();
                    PlayingSounds[device].Init(new AudioFileReader(_path));
                    PlayingSounds[device].Play();
            }

           //foreach(var sound in PlayingSounds)
            //{
            //    sound.Value.Stop();
            //    sound.Value.Init(new AudioFileReader(_path));
            //    sound.Value.Play();
            //}

            _isLooping = true;
        }


        void audioOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            var v = sender as WaveOut;

            if (_loop && _isLooping)
            {
                PlayingSounds[v.DeviceNumber].Stop();
                PlayingSounds[v.DeviceNumber].Init(new AudioFileReader(_path));
                PlayingSounds[v.DeviceNumber].Play();
            }
        }

        public void Stop()
        {
            foreach (var sound in PlayingSounds)
            {
                sound.Value.Stop();
            }
            _isLooping = false;
            IsFinished = true;
        }

        private void SetFinished(object sender, EventArgs e)
        {
            IsFinished = true;
        }

        public void ChangeVolume(double newVol)
        {
            _volume = newVol;
            foreach (var sound in PlayingSounds)
            {
                sound.Value.Volume = (float)(newVol * _masterVol);
            }           
        }

        public void ChangeMasterVolume(double newVol)
        {
            _masterVol = newVol;
            foreach (var sound in PlayingSounds)
            {
                sound.Value.Volume = (float)(newVol * _volume);
            }
        }

        public double GetVolume()
        {
            return _volume;
        }
    }
}
