# SSV

DotNet Core Console App to toggle Input Device "Listen through this device" between two devices using SoundVolumeView

### What it does

This program, on execution, reads the Toggle value from the registry, and invokes SoundVolumeView.exe with the arguments "/RunAsAdmin /SetPlaybackThroughDevice {Input} {Output}" using the value of OutputA or OutputB.

It's meant to be a fire-and-forget solution for quickly swapping Virtual Audio Cables between output devices.

### Prerequisites

- Nirsoft's [SoundVolumeView](https://www.nirsoft.net/utils/sound_volume_view.html), which this App invokes.

### Configuring

The configuration is read from the Registry:

- SoundVolumeView: `SoundVolumeView.exe` must be available in the PATH, or it's full path configured via the key `HKEY_CURRENT_USER\Software\meoiswa\ssv\SoundVolumeViewPath`.

- Devices: ([Check here for naming rules](https://www.nirsoft.net/utils/sound_volume_view.html#command_line))
  - Input: (String) `HKEY_CURRENT_USER\Software\meoiswa\ssv\Input`.
  - Output A: (String) `HKEY_CURRENT_USER\Software\meoiswa\ssv\OutputA`.
  - Output B: (String) `HKEY_CURRENT_USER\Software\meoiswa\ssv\OutputB`.