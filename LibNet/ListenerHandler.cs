﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mognetwork
{
    interface ListenerHandler
    {
        public void onMessageReceived(List<byte> datas);
    }
}
