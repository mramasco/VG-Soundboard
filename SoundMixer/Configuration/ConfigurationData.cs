using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Soundboard.Configuration
{
    public class SoundBoardConfigurationData
    {
        public List<TabConfiguration> Tabs { get; set; }
        public double Transparency { get; set; }
        public Keys MasterStopHotKey { get; set; }
        public ModifierKeys MasterStopModifier { get; set; }
        public double MasterVolume { get; set; }
    }

    public class TabConfiguration
    {
        public List<ButtonConfiguration> Buttons { get; set; }
        public string TabName { get; set; }
    }

    public class ButtonConfiguration
    {
        public string SoundLocation { get; set; }
        public Keys HotKey { get; set; }
        public ModifierKeys ModifierKey { get; set; }
        public string ButtonText { get; set; }
        public bool Loop { get; set; }
        public double Volume { get; set; }
    }
}
