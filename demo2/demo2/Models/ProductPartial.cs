using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo2.Models;

namespace demo2.Models
{
    public partial class Product
    {
        public string ManufactName { get { return Productmanuf.Manufname; } }
    }
}
