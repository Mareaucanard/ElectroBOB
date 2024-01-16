using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchMail
{
    public class GenericTriggers
    {
        public bool minThreshold(float threshold, float value)
        {
            if (value < threshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool maxThreshold(float threshold, float value)
        {
            if (value > threshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool postFromUser(string user, string targetUser) 
        {
            if (user == targetUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
