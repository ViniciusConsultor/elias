﻿using System;

namespace Alfa.Core.Exception
{
    public sealed class DefaultHandlerMessage : IHandlerMessage
    {
        private static volatile DefaultHandlerMessage instance;
        private static object syncRoot = new Object();

        private DefaultHandlerMessage()
        { }

        public static DefaultHandlerMessage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DefaultHandlerMessage();
                    }
                }

                return instance;
            }
        }

        public void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
