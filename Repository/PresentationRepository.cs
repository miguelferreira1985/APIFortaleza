using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Repository
{
    public class PresentationRepository
    {
        DALPresentation dalPresentation;
        public List<Presentation> getActivePresentation()
        {
            dalPresentation = new DALPresentation();
            return dalPresentation.dalGetActivePresentations();
        }
    }
}
