using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingAndSaveTextInDb.Models
{
    public class FileInformation
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int Count { get; set; }
        public byte[] Sentence { get; set; }
    }
}