using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Repository
{
     public class ColorRepository
    {

        DALColor dalColor;
        public List<Color> getActiveColor()
        {
            dalColor = new DALColor();
            return dalColor.dalGetActiveColors();
        }

        public bool updateColor(Color color)
        {
            dalColor = new DALColor();
            return  dalColor.dalUpdateColor(color);
        }

        public bool deleteColor(int id)
        {
            dalColor = new DALColor();
            return dalColor.dalDeleteColor(id);
        }
    }
}
