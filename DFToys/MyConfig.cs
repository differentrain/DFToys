﻿using DFToys.PvfCache;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DFToys
{
    public sealed class MyConfig
    {
        public static readonly MyConfig Shared;


        static MyConfig()
        {
            if (File.Exists("MyConfig.json"))
            {
                FileStream fs;
                try
                {
                    fs = new FileStream("MyConfig.json", FileMode.Open);
                    MyConfig config = JsonSerializer.Deserialize<MyConfig>(fs);
                    Shared = config ?? new MyConfig();
                }
                catch
                {
                    Shared = new MyConfig();
                }
            }
            else
            {
                Shared = new MyConfig();
            }
        }

        public string Ip { get; set; } = "192.168.200.131";

        public int Port { get; set; } = 3306;

        public string DbId { get; set; } = "game";

        public string Pwd { get; set; } = "uu5!^%jg";

        public string UName { get; set; } = string.Empty;

        public string DfPath { get; set; } = @"..\dnf.exe";

        public string PvfPath { get; set; } = @"..\script.pvf";

        public bool TopMost { get; set; } = false;


        public void Save()
        {
            FileStream fs;
            try
            {
                fs = new FileStream("MyConfig.json", FileMode.Create);
                JsonSerializer.Serialize(fs, this);
            }
            catch { }
        }

    }
}
