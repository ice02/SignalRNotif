﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NotificationJson { get; set; }
    }
}