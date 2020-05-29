using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Presentation
    {
        public int PresentationID { get; set; }
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public string Descripton { get; set; }
        public bool IsActivated { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Presentation()
        {

        }

        public Presentation(int presentationId, string name, string abbrevation, string description, bool isActivated, DateTime createdDate, DateTime modifiedDate)
        {
            this.PresentationID = presentationId;
            this.Name = name;
            this.Abbrevation = abbrevation;
            this.Descripton = description;
            this.IsActivated = isActivated;
            this.CreatedDate = createdDate;
            this.ModifiedDate = modifiedDate;
        }
    }
}
