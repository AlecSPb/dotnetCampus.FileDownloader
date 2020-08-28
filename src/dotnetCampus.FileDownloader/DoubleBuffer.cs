﻿using System.Collections.Generic;

namespace dotnetCampus.FileDownloader
{
    class DoubleBuffer<T>
    {
        public DoubleBuffer()
        {
            CurrentList = AList;
        }

        public void Add(T t)
        {
            lock (_lock)
            {
                CurrentList.Add(t);
            }
        }

        public List<T> SwitchBuffer()
        {
            lock (_lock)
            {
                if (ReferenceEquals(CurrentList, AList))
                {
                    CurrentList = BList;
                    return AList;
                }
                else
                {
                    CurrentList = AList;
                    return BList;
                }
            }
        }

        private readonly object _lock = new object();

        private List<T> CurrentList { set; get; }

        private List<T> AList { get; } = new List<T>();
        private List<T> BList { get; } = new List<T>();
    }
}