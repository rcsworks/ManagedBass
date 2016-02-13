﻿using ManagedBass.Dynamics;
using System;

namespace ManagedBass
{
    class AsioDevice : IDisposable
    {
        public int DeviceIndex { get; private set; }

        public AsioDeviceInfo DeviceInfo { get { return BassAsio.GetDeviceInfo(DeviceIndex); } }

        public double SampleRate
        {
            get
            {
                BassAsio.CurrentDevice = DeviceIndex;
                return BassAsio.Rate;
            }
            set
            {
                BassAsio.CurrentDevice = DeviceIndex;
                BassAsio.Rate = value;
            }
        }

        public bool IsStarted
        {
            get
            {
                BassAsio.CurrentDevice = DeviceIndex;
                return BassAsio.IsStarted;
            }
        }

        public Return<bool> Init(bool DedicatedThread = false)
        {
            return BassAsio.Init(DeviceIndex, DedicatedThread ? AsioInitFlags.Thread : AsioInitFlags.None);
        }

        public void Dispose()
        {
            BassAsio.CurrentDevice = DeviceIndex;
            BassAsio.Free();
        }
    }
}
