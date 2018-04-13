using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    [Serializable]
    class BlockInfo
    {
        int moneyTransferred;
        string sender;
        string receiver; 
        
        public BlockInfo(int moneyTransferred, string sender, string receiver)
        {
            this.moneyTransferred = moneyTransferred;
            this.sender = sender;
            this.receiver = receiver;
        }

        public override string ToString()
        {
            string ret = "";
            ret += "money transferred: " + this.moneyTransferred + ", ";
            ret += "sender: " + this.sender + ", ";
            ret += "receiver: " + this.receiver;
            return ret;

        }
    }
}
