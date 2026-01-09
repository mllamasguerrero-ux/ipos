using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LoginInfo
{
    public class CurrentUser
    {
        private static long m_idUserId;
        public static long m_IdUserId
        {
            get
            {
                return m_idUserId;
            }
            set
            {
                m_idUserId = value;
            }
        }
    }
}
