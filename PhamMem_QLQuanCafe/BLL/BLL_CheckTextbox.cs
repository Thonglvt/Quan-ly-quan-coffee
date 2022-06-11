using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_CheckTextbox
    {
        public static bool CheckPhone(string phone)
        {
            //Chuỗi định dạng email
            String reg = "^(0|\\+84)(\\s|\\.)?((3[2-9])|(5[689])"
                        + "|(7[06-9])|(8[1-689])|(9[0-46-9]))"
                        + "(\\d)(\\s|\\.)?(\\d{3})(\\s|\\.)?(\\d{3})$";
            Regex re = new Regex(reg);
            return re.IsMatch(phone);
        }
    }
}
