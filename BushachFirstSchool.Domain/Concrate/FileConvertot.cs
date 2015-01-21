using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Concrate
{
   public  static class FileConvertot
    {
       public static byte[] ToArray( this Stream input)
       {
           MemoryStream ms = new MemoryStream();
           input.CopyTo(ms);
           var byts = ms.ToArray();
           ms.Dispose();
           return byts;
       }
    }
}
