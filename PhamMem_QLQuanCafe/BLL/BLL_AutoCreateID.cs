using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class BLL_AutoCreateID
    {
        DAL_AutoCreateID dalAutoCreateID;
        public string create_ID_NV()
        {
            dalAutoCreateID = new DAL_AutoCreateID();
            return dalAutoCreateID.create_ID_NV();
        }

        public string create_ID_HD()
        {
            dalAutoCreateID = new DAL_AutoCreateID();
            return dalAutoCreateID.create_ID_HD();
        }
    }
}
