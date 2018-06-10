using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildMath.Model
{
    public class Question
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int MathOperations { get; set; }
        public int Result { get; set; }
        public int Answer { get; set; }
    }
}
