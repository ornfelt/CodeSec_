﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSec.Models { //removed .Poco
  public class Picture {
    public int PictureId { get; set; }
    public string PictureName { get; set; }
    public int SickNoteId { get; set; }
  }
}
