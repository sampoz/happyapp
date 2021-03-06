﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MiniBrowser
{
    public class Task
    {
        String name { get; set; }
        private String _description;
        public String Description
        { get { return _description; } }
        String imgSrc { get; set; }

        public int status = 0;

        int healthy;
        public Task(String name, String des, String imgSrc)
        {
            this.imgSrc = imgSrc;
            this.name = name;
            this._description = des;
            if (imgSrc == null)
            {
                imgSrc = "";
            }

        }

        public String getImgSrc()
        {
            return this.imgSrc;
        }
        public void setImgSrc(String src)
        {
            this.imgSrc= src;
        }
        public String getName()
        {
            return this.name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setHealthy(int h)
        {
            this.healthy = h;
        }
        public int getHealthy()
        {
            return this.healthy;
        }

    }
}
