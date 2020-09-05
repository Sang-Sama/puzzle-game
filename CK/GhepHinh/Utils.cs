using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhepHinh
{
    public class Utils
    {
        static Random _Rd = new Random();

        public static Random Rd { get => _Rd; set => _Rd = value; }
    }
}
