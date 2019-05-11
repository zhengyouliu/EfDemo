using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime? CreateTime { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }

        //public string Remark { get; set; }
    }
}
