﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class Quotes
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
