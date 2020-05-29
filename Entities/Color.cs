using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Color
    {
        public int ColorID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActivated { get; set; }

        public Color()
        {

        }

        public Color(int colorId, string name, DateTime createdDate, DateTime modifiedDate, bool isActivated)
        {
            this.ColorID = colorId;
            this.Name = name;
            this.CreatedDate = createdDate;
            this.ModifiedDate = modifiedDate;
            this.IsActivated = isActivated;
        }
    }
}
