using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace raem
{
    public partial class frmCoreConfig : Form
    {
        string strCoreCFG;
        ListViewItem lviEditing;
        Dictionary<string, string> dDescriptions;

        public frmCoreConfig(string strInCoreCFG)
        {
            InitializeComponent();    
            dDescriptions = new Dictionary<string, string>();
            fnLoadDescriptions();
            strCoreCFG = strInCoreCFG;
        }

        private void frmCoreConfig_Load(object sender, EventArgs e)
        {
            gbSystemName.Text = " Configuring: " + Path.GetFileNameWithoutExtension(strCoreCFG) + " ";
            fnLoadCFG();
        }

        private void fnLoadCFG()
        {
            lvCoreOptions.Sorting = SortOrder.Ascending;

            StreamReader srIn = new StreamReader(strCoreCFG);
            String strTemp = srIn.ReadToEnd();
            string[] strLines = strTemp.Split(Environment.NewLine.ToCharArray());
            srIn.Close();

            foreach (string strLine in strLines)
            {
                if (strLine.Length > 0)
                {
                    string strOption = strLine.Split('=')[0].Trim();
                    string strValue = strLine.Split('=')[1].Trim().Replace("\"", string.Empty);

                    ListViewItem lviNew = new ListViewItem();
                    lviNew.Text = strOption;
                    lviNew.SubItems.Add(strValue);
                    lvCoreOptions.Items.Add(lviNew);
                }
            }          
        }

        private void lvCoreOptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            

            if (lvCoreOptions.SelectedItems.Count > 0)
            {
                lviEditing = lvCoreOptions.SelectedItems[0];

                frmChangeValue newChangeValue = new frmChangeValue(lvCoreOptions.SelectedItems[0].Text, lvCoreOptions.SelectedItems[0].SubItems[1].Text);
                newChangeValue.ShowDialog();

                if (newChangeValue.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    lvCoreOptions.Items.Remove(lviEditing);

                    ListViewItem lviNew = new ListViewItem();
                    lviNew.Text = newChangeValue.strOption;
                    lviNew.SubItems.Add(newChangeValue.strValue);
                    lvCoreOptions.Items.Add(lviNew);
                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fnSaveConfig();
        }

        private void fnSaveConfig()
        {
            StreamWriter srOut = new StreamWriter(strCoreCFG, false);

            foreach(ListViewItem lviCurrent in lvCoreOptions.Items)
            {
                string strOptionName = lviCurrent.Text;
                string strOptionValue = lviCurrent.SubItems[1].Text;

                srOut.WriteLine(strOptionName + " = \"" + strOptionValue + "\"");
            }

            srOut.Flush();
            srOut.Flush();
            srOut.Close();
        }

        private void lvCoreOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCoreOptions.SelectedItems.Count > 0)
            {
                lblDescription.Text = string.Empty;
                gbOptionName.Text = lvCoreOptions.SelectedItems[0].Text;
                try
                {
                    lblDescription.Text = dDescriptions[lvCoreOptions.SelectedItems[0].Text];
                }
                catch { }
            }
        }

        private void fnLoadDescriptions()
        {
            dDescriptions.Add("load_dummy_on_core_shutdown", "Prevents crashes (set to true)");
            dDescriptions.Add("video_xscale", "Real x res = aspect * base_size * xscale");
            dDescriptions.Add("video_yscale", "Real y res = base_size * yscale");
            dDescriptions.Add("video_fullscreen", "To start in Fullscreen or not.");
            dDescriptions.Add("video_windowed_fullscreen", "To use windowed mode or not when going fullscreen.");
            dDescriptions.Add("video_monitor_index", "Which monitor to prefer. 0 is any monitor, 1 and up selects specific monitors, 1 being the first monitor.");
            dDescriptions.Add("video_fullscreen_x", "Fullscreen Width resolution. A value of 0 uses the desktop resolution.");
            dDescriptions.Add("video_fullscreen_y", "Fullscreen Height resolution. A value of 0 uses the desktop resolution.");
            dDescriptions.Add("video_disable_composition", "Forcibly disable composition. Only valid on Windows Vista/7 for now.");
            dDescriptions.Add("video_vsync", "Video VSYNC (recommended)");
            dDescriptions.Add("video_hard_sync", "Attempts to hard-synchronize CPU and GPU. Can reduce latency at cost of performance.");
            dDescriptions.Add("video_hard_sync_frames", "Configures how many frames the GPU can run ahead of CPU");
            dDescriptions.Add("video_black_frame_insertion", "Inserts a black frame inbetween frames, Useful for 120 Hz monitors");
            dDescriptions.Add("video_swap_interval", "Uses a custom swap interval for VSync.  Set this to effectively halve monitor refresh rate.");
            dDescriptions.Add("video_threaded", "Threaded video. Will possibly increase performance significantly at cost of worse synchronization and latency.");
            dDescriptions.Add("video_shared_context", "Set to true if HW render cores should get their private context.");
            dDescriptions.Add("video_smooth", "Smooths picture");
            dDescriptions.Add("video_shader_enable", "Enable use of shaders.");
            dDescriptions.Add("video_scale_integer", "Only scale in integer steps. The base size depends on system-reported geometry and aspect ratio. If video_force_aspect is not set, X/Y will be integer scaled independently.");
            dDescriptions.Add("video_aspect_ratio", "Controls aspect ratio handling.");
            dDescriptions.Add("aspect_ratio_index", "Sets Aspect ratio");
            dDescriptions.Add("config_save_on_exit", "Save configuration file on exit");
            dDescriptions.Add("video_crop_overscan", "Crop overscanned frames.");
            dDescriptions.Add("video_font_size", "Font size for on-screen messages.");
            dDescriptions.Add("video_font_scale", "Attempt to scale the font size.  The scale factor will be window_size / desktop_size.");
            dDescriptions.Add("message_pos_offset_x", " Offset for where messages will be placed on-screen. Values are in range [0.0, 1.0].");
            dDescriptions.Add("message_pos_offset_y", " Offset for where messages will be placed on-screen. Values are in range [0.0, 1.0].");
            dDescriptions.Add("message_color", "Color of the message.  RGB hex value.");
            dDescriptions.Add("video_post_filter_record", "Record post-filtered (CPU filter) video rather than raw game output.");
            dDescriptions.Add("video_gpu_screenshot", "Screenshots post-shaded GPU output if available.");
            dDescriptions.Add("video_gpu_record", "Record post-shaded GPU output instead of raw game footage if available.");
            dDescriptions.Add("video_font_enable", "OSD-messages");
            dDescriptions.Add("video_refresh_rate", "The accurate refresh rate of your monitor (Hz).");
            dDescriptions.Add("video_rotation", "Allow games to set rotation. If 0, rotation requests are honored, but ignored.");
            dDescriptions.Add("audio_enable", "Will enable audio or not.");
            dDescriptions.Add("audio_out_rate", "Output samplerate");
            dDescriptions.Add("audio_device", "Audio device (e.g. hw:0,0 or /dev/audio). If NULL, will use defaults.");
            dDescriptions.Add("audio_latency", "Desired audio latency in milliseconds. Might not be honored if driver can't provide given latency.");
            dDescriptions.Add("audio_sync", " Will sync audio. (recommended)");
            dDescriptions.Add("audio_resampler", "Default resampler");
            dDescriptions.Add("audio_rate_control", "Experimental rate control");
            dDescriptions.Add("audio_rate_control_delta", "Rate control delta. Defines how much rate_control is allowed to adjust input rate.");
            dDescriptions.Add("audio_volume", "Default audio volume in dB. (0.0 dB == unity gain).");
            dDescriptions.Add("rewind_enable", "Enables use of rewind. This will incur some memory footprint depending on the save state buffer.");
            dDescriptions.Add("rewind_buffer_size", "The buffer size for the rewind buffer. This needs to be about 15-20MB per minute. Very game dependant.");
            dDescriptions.Add("rewind_granularity", "How many frames to rewind at a time.");
            dDescriptions.Add("pause_nonactive", "Pause gameplay when gameplay loses focus.");
            dDescriptions.Add("autosave_interval", "Saves non-volatile SRAM at a regular interval. It is measured in seconds. A value of 0 disables autosave.");
            dDescriptions.Add("netplay_client_swap_input", "When being client over netplay, use keybinds for player 1 rather than player 2.");
            dDescriptions.Add("block_sram_overwrite", "On save state load, block SRAM from being overwritten, This could potentially lead to buggy games.");
            dDescriptions.Add("savestate_auto_index", "When saving savestates, state index is automatically incremented before saving.  When the ROM is loaded, state index will be set to the highest existing value.");
            dDescriptions.Add("savestate_auto_save", "Automatically saves a savestate at the end of RetroArch's lifetime.");
            dDescriptions.Add("savestate_auto_load", "RetroArch will automatically load any savestate with this path on startup if savestate_auto_load is set.");
            dDescriptions.Add("slowmotion_ratio", "Slowmotion ratio.");
            dDescriptions.Add("fastforward_ratio", "Maximum fast forward ratio (Negative => no limit).");
            dDescriptions.Add("network_cmd_enable", "Enable stdin/network command interface");
            dDescriptions.Add("network_cmd_port", "Network Port");
            dDescriptions.Add("stdin_cmd_enable", "Enable stdin/network command interface");
            dDescriptions.Add("game_history_size", "Number of entries that will be kept in ROM history file.");
            dDescriptions.Add("rgui_show_start_screen", "Show RGUI start-up screen on boot.");
            dDescriptions.Add("libretro_log_level", "Log level for libretro cores (GET_LOG_INTERFACE).");
            dDescriptions.Add("input_axis_threshold", "Axis threshold (between 0.0 and 1.0)  How far an axis must be tilted to result in a button press");
            dDescriptions.Add("turbo_period", "Describes speed of which turbo-enabled buttons toggle.");
            dDescriptions.Add("turbo_duty_cycle", "Describes speed of which turbo-enabled buttons toggle.");
            dDescriptions.Add("input_debug_enable", "Enable input debugging output.");
            dDescriptions.Add("input_autodetect_enable", "Enable input auto-detection. Will attempt to autoconfigure gamepads, plug-and-play style.");
        }
    }
}
