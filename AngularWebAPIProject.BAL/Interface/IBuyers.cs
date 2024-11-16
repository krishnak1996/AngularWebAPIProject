using AngularWebAPIProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.BAL.Interface
{
    public interface IBuyers
    {
        ResponseModel GetBuyersById(int PFID);
        ResponseModel SaveBuyers(BuyersModel buyersModel);
    }
}
