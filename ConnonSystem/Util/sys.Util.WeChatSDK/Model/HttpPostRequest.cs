﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sys.Util.WeChat.Helper;

namespace sys.Util.WeChat.Model
{
    public class HttpPostRequest : IHttpSend
    {
        public string Send(string url, string data)
        {
            return new HttpHelper().Post(url, data, Encoding.UTF8, Encoding.UTF8);
        }
    }
}
